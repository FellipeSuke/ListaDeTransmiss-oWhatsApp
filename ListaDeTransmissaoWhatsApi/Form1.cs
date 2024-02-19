using ListaDeTransmissaoWhatsApi.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Text.RegularExpressions;

namespace ListaDeTransmissaoWhatsApi
{
    public partial class Form1 : Form
    {
        //Variaveis Ambiente
        public string sessionId;
        //public string host = "https://whatsapi.up.railway.app/";
        public string host = "http://apisuke.ddns.net:3000/";
        //public string host = "http://191.220.2.201:3000";
        public string keyName = "x-api-key";
        public string keyValue = "ApiWhatsApp";

        public Form1()
        {
            InitializeComponent();
            sessionId = tbSessionId.Text;
            PingSystem();
            tbSessionId.Text = Properties.Settings.Default.sessao;
            PreencherCheckListBoxComArquivos();


        }

        public void PrintMessage(RestResponse response, string comando)
        {
            var responseData = DesserializeResponse(response);

            if (responseData.Success)
            {
                labelResponse.Text = $"{comando}{Environment.NewLine}{responseData.Message}";


            }
            else if (!responseData.Success)
            {
                if (responseData.Error is not null)
                {
                    labelResponse.Text = $"Falha{Environment.NewLine}{responseData.Error}";
                }
                else
                {
                    labelResponse.Text = $"Falha{Environment.NewLine}{responseData.Message}";
                }

            }
            else
            {
                labelResponse.Text = "Sem Dados de Sucesso";
            }

        }

        private async void cbIniciarsessao_Click(object sender, EventArgs e)
        {
            Processando();
            RestResponse response = await RequestRestGetAsync("/session/start/");
            PrintMessage(response, $"Sessão {sessionId} Conectado");
            tbSessionId.Enabled = false;
            ShowQRCodeAsync(response);

        }

        private async void cbEncerraSessao_Click(object sender, EventArgs e)
        {
            Processando();
            RestResponse response = await RequestRestGetAsync("/session/terminate/");
            PrintMessage(response, $"Sessão {sessionId} Encerrada");
            tbSessionId.Enabled = true;

        }

        private async void cbStats_Click(object sender, EventArgs e)
        {
            Processando();
            RestResponse response = await RequestRestGetAsync("/session/status/");
            PrintMessage(response, $"Sessão {sessionId} ");

        }

        private async Task ShowQRCodeAsync(RestResponse cache)
        {
            Processando();
            int i = 0;
        AtualizaQrCode:

            RestResponse responseStatus = await RequestRestGetAsync("/session/status/");
            var status = DesserializeResponse(responseStatus);

            if (status.State != "CONNECTED")
            {

                bool checkImg = true;
                RestResponse response = new();
                StartSession responseData = new();
                try
                {
                    Thread.Sleep(1000);
                    i++;
                    while (checkImg)
                    {
                        response = await RequestRestGetAsync($"/session/qr/", "/Image", "image/png");
                        //responseData = JsonConvert.DeserializeObject<StartSession>(response.Content);
                        if (response.ContentType != "image/png")
                        {
                            Thread.Sleep(1000);
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    var ms = new MemoryStream(response.RawBytes);
                    pbQrCode.Image = System.Drawing.Image.FromStream(ms);
                    PrintMessage(cache, $"Sessão {sessionId} Conectado");
                    pbQrCode.Visible = true;
                    cbRefreshQrCode.Visible = true;
                    labelResponse.Text = $"Aguardando QR Code... {i}Seg";
                    if (i < 60)
                    {
                        goto AtualizaQrCode;
                    }
                    else
                    {
                        labelResponse.Text = $"Aguardando QR Code...........";
                    }




                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                PrintMessage(responseStatus, $"Sessão {sessionId} {status.State}");
                pbQrCode.Visible = false;
            }

        }

        private async Task<RestResponse> RequestRestGetAsync(string caminhoSession, string optional = "", string contentType = "application/json")
        {
            var options = new RestClientOptions(host)
            {
                MaxTimeout = -1,

            };
            var client = new RestClient(options);
            var request = new RestRequest(caminhoSession + sessionId + optional, Method.Get);
            request.AddHeader(keyName, keyValue);
            request.AddHeader("Content-Type", contentType);
            return await client.ExecuteAsync(request);
        }

        private async Task PostMessageWhatsapp(string ItensMarcados, string host)
        {
            var options = new RestClientOptions(host)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/client/sendMessage/{sessionId}", Method.Post);
            request.AddHeader(keyName, keyValue);
            request.AddHeader("Content-Type", "application/json");

            var usuarioTarget = DadosDoEnvioUsuario(ItensMarcados);

            string ReplaceDeVariaveisMsg = tbCampoMessage.Text.Replace("@PrimeiroNomeContato@", usuarioTarget.PrimeiroNome.ToString()).Replace("@NomeCompletoDoContato@", usuarioTarget.NomeCompleto.ToString()).Replace("@NumeroDoContato@", usuarioTarget.Numero.ToString());

            string textoSemQuebrasDeLinha = ReplaceDeVariaveisMsg.Replace("\n", @"\n").Replace("\r", @"\r");

            var body = @"{
" + "\n" +
  @$"  ""chatId"": ""{usuarioTarget.Numero}"",
" + "\n" +
  @"  ""contentType"": ""string"",
" + "\n" +
  @$"  ""content"": ""{textoSemQuebrasDeLinha}""
" + "\n" +
  @"}";

            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            labelResponse.Text = response.ResponseStatus.ToString();

        }

        private StartSession DesserializeResponse(RestResponse response)
        {
            return JsonConvert.DeserializeObject<StartSession>(response.Content);
        }

        private void Processando()
        {
            labelResponse.Text = "Processando...";
            pbQrCode.Visible = false;
            cbRefreshQrCode.Visible = false;
        }

        private async void cbRefreshQrCode_Click(object sender, EventArgs e)
        {
            try
            {
                string cache = labelResponse.Text;
                Processando();
                var response = await RequestRestGetAsync($"/session/qr/", "/Image", "image/png");

                var ms = new MemoryStream(response.RawBytes);
                pbQrCode.Image = System.Drawing.Image.FromStream(ms);
                labelResponse.Text = cache;
                pbQrCode.Visible = true;
                cbRefreshQrCode.Visible = true;
            }
            //teste

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Campo_Leave(object sender, EventArgs e)
        {
            TextBox campo = sender as TextBox;
            if (campo.Text != "")
            {
                if (campo.Text.Length != 13)
                {
                    MessageBox.Show("Número de celular inválido. Por favor, insira um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    campo.Focus(); // Volta o foco para o TextBox
                }
                else
                {
                    sessionId = tbSessionId.Text;
                }
            }

        }

        private void Campo_TextChanged(object sender, EventArgs e)
        {
            TextBox campo = sender as TextBox;



            string phoneNumber = new string(campo.Text.Where(c => char.IsDigit(c)).ToArray());

            // Formata o número como xx-xxxx-xxxx
            if (phoneNumber.Length > 0)
            {
                // Se a string tiver mais de 2 dígitos, insere o primeiro hífen
                if (phoneNumber.Length > 2)
                    phoneNumber = phoneNumber.Insert(2, "-");
                // Se a string tiver mais de 8 dígitos, insere o segundo hífen
                if (phoneNumber.Length > 8)
                    phoneNumber = phoneNumber.Insert(8, "-");
            }

            // Define o texto formatado no TextBox
            campo.Text = phoneNumber;
            // Define o cursor no final do texto
            campo.SelectionStart = campo.Text.Length;
        }

        private void Valida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela o evento
            }
        }

        private void cbAddContato_Click(object sender, EventArgs e)
        {
            if (tbNomeContato.Text != "" && tbNumeroContato.Text != "")
            {
                string contatoWhatsapp = FormatarNumeroWhatsApp(tbNumeroContato.Text);
                clbContatos.Items.Add((contatoWhatsapp + "; " + tbNomeContato.Text), true);
                foreach (var item in clbContatos.Items)
                {
                    tbNomeContato.Clear();
                    tbNumeroContato.Clear();
                    tbNumeroContato.Focus();
                }
            }
            else
            {
                MessageBox.Show($"Campos Obrigatórios não Preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        } //Atenção aqui, falta campo obrigatórios

        static string FormatarNumeroWhatsApp(string telefone)
        {
            string numeroLimpo = Regex.Replace(telefone, "[^0-9]", "");

            // Remove o primeiro '9' caso esteja presente
            if (numeroLimpo.Length > 10)
            {
                numeroLimpo = numeroLimpo.Remove(2, 1);
            }

            // Adiciona o código do país e o sufixo "@c.us"
            return "55" + numeroLimpo + "@c.us";
        }

        private void cbEnviarMensagem_Click(object sender, EventArgs e)
        {
            Processando();
            string itensMarcados = "Mensagens enviada para:\n";

            foreach (var item in clbContatos.CheckedItems)
            {
                itensMarcados += item.ToString() + "\n";
                PostMessageWhatsapp(item.ToString(), host);

            }
            MessageBox.Show(itensMarcados);





        }

        private DadosDoUsuario DadosDoEnvioUsuario(string ItenMarcados)
        {
            DadosDoUsuario usuario = new();

            string contato = ItenMarcados;

            // Dividir a string usando o ponto e vírgula como delimitador
            string[] partes = contato.Split("; ");

            if (partes.Length == 2)
            {
                usuario.Numero = partes[0];
                usuario.NomeCompleto = partes[1];

                // Dividir o nome completo em partes usando espaço como delimitador
                string[] nomePartes = usuario.NomeCompleto.Split(' ');

                // Primeiro nome é a primeira parte
                usuario.PrimeiroNome = nomePartes[0];

            }
            return usuario;
        }

        private void cbConnectar_Click(object sender, EventArgs e)
        {
            LabelServidor.Text = "Conectando";
            LabelServidor.BackColor = Color.FromArgb(255, 240, 240, 240);
            PingSystem();
        }

        private async Task<string> PingSystem()
        {
            var options = new RestClientOptions(host)
            {
                MaxTimeout = 1000,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/PING", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            var responseData = DesserializeResponse(response);

            if (responseData.Success)
            {
                LabelServidor.Text = $"Servidor: Conectado";
                LabelServidor.BackColor = Color.YellowGreen;
                cbConnectar.Visible = false;
                return responseData.Message;

            }
            else if (!responseData.Success)
            {
                if (responseData.Error is not null)
                {
                    LabelServidor.Text = $"Falha{Environment.NewLine}{responseData.Error}";
                    LabelServidor.BackColor = Color.IndianRed;
                    cbConnectar.Visible = true;
                    return responseData.Error;
                }
                else
                {
                    LabelServidor.Text = $"Falha{Environment.NewLine}{responseData.Message}";
                    LabelServidor.BackColor = Color.IndianRed;
                    cbConnectar.Visible = true;
                    return responseData.Message;
                }

            }
            else
            {
                LabelServidor.Text = "Sem Dados de Sucesso";
                return "Sem Dados de Sucesso";
            }
        }

        private void cbPrimeiroNome_Click(object sender, EventArgs e)
        {
            VariaveisDeTexto(" @PrimeiroNomeContato@ ");
        }

        private void cbNomeCompleto_Click(object sender, EventArgs e)
        {
            VariaveisDeTexto(" @NomeCompletoDoContato@ ");
        }

        private void VariaveisDeTexto(string variavelTexto)
        {
            int posicaoCursor = tbCampoMessage.SelectionStart;

            // Insere o texto na posição do cursor
            tbCampoMessage.Text = tbCampoMessage.Text.Insert(posicaoCursor, variavelTexto);

            // Move o cursor para o final do texto inserido
            tbCampoMessage.SelectionStart = posicaoCursor + variavelTexto.Length;
            tbCampoMessage.SelectionLength = 0; // Desmarca o texto selecionado, se houver
            tbCampoMessage.Focus();
        }

        private void cbSelectAll_Click(object sender, EventArgs e) // EM CONSTRUÇÂO
        {
            if (clbContatos.GetItemChecked(0))
            {
                for (int i = 0; i < clbContatos.Items.Count; i++)
                {
                    clbContatos.SetItemChecked(i, false);
                }

            }
            else
            {
                for (int i = 0; i < clbContatos.Items.Count; i++)
                {
                    clbContatos.SetItemChecked(i, true);
                }
            }

        }

        private void cbExcluir_Click(object sender, EventArgs e)
        {
            int numeroDeContatosMarcados = clbContatos.CheckedItems.Count;
            DialogResult result = MessageBox.Show($"Tem certeza que deseja excluir {numeroDeContatosMarcados} contatos selecionado(s)?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                List<int> indicesParaRemover = new List<int>();

                // Itera pelos itens selecionados
                foreach (int indice in clbContatos.CheckedIndices)
                {
                    indicesParaRemover.Add(indice); // Adiciona o índice à lista de índices para remover
                }

                // Itera pelos índices para remover e remove os itens correspondentes do CheckedListBox
                for (int i = indicesParaRemover.Count - 1; i >= 0; i--)
                {
                    clbContatos.Items.RemoveAt(indicesParaRemover[i]);
                }
            }
        }

        private void cbSalvarGrupo_Click(object sender, EventArgs e)
        {
            string nomeArquivo = tbNomeDoArquivoDeGrupo.Text; // Obtém o nome do arquivo do TextBox

            // Verifica se o nome do arquivo não está vazio
            if (!string.IsNullOrWhiteSpace(nomeArquivo))
            {
                // Diretório onde os arquivos serão salvos
                string diretorioGrupos = Path.Combine(Application.StartupPath, "Grupos");

                // Verifica se o diretório Grupos não existe e cria se necessário
                if (!Directory.Exists(diretorioGrupos))
                {
                    Directory.CreateDirectory(diretorioGrupos);
                }

                string caminhoCompleto = Path.Combine(diretorioGrupos, nomeArquivo + ".txt"); // Prepara o caminho completo do arquivo

                // Salva os itens do CheckedListBox no arquivo de texto
                SalvarItensCheckListBox(caminhoCompleto);
                MessageBox.Show("Itens salvos com sucesso!");
            }
            else
            {
                MessageBox.Show("Por favor, insira um nome de arquivo válido.");
            }
        }

        private void SalvarItensCheckListBox(string caminhoArquivo)
        {
            // Escreve os itens do CheckedListBox no arquivo de texto
            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                foreach (var item in clbContatos.CheckedItems)
                {
                    writer.WriteLine(item.ToString());
                }
            }
            PreencherCheckListBoxComArquivos();
        }

        private void PreencherCheckListBoxComArquivos()
        {
            clbGrupoDeContado.Items.Clear();
            // Especifique o diretório onde estão os arquivos
            string diretorio = Path.Combine(Application.StartupPath, "Grupos");

            // Verifica se o diretório existe
            if (Directory.Exists(diretorio))
            {
                // Obtem uma lista dos arquivos no diretório
                string[] arquivos = Directory.GetFiles(diretorio);

                // Adiciona cada nome de arquivo ao CheckListBox
                foreach (string arquivo in arquivos)
                {
                    // Obtém apenas o nome do arquivo sem o caminho completo e sem a extensão
                    string nomeArquivo = Path.GetFileNameWithoutExtension(arquivo);

                    // Adiciona o nome do arquivo ao CheckListBox
                    clbGrupoDeContado.Items.Add(nomeArquivo);
                }
            }
            else
            {
                // Se o diretório não existe, exibe uma mensagem de erro
                //MessageBox.Show("O diretório especificado não existe.");
            }
        }

        private void cbImportContatosDeGrupo_Click(object sender, EventArgs e)
        {

            foreach (string nomeArquivo in clbGrupoDeContado.CheckedItems)
            {
                string caminhoArquivo = Path.Combine(Application.StartupPath, "Grupos", nomeArquivo + ".txt");

                if (File.Exists(caminhoArquivo))
                {
                    string[] linhas = File.ReadAllLines(caminhoArquivo);
                    foreach (string linha in linhas)
                    {
                        clbContatos.Items.Add(linha, true);
                    }
                }
                else
                {
                    MessageBox.Show($"Arquivo '{nomeArquivo}' não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbExcluirGrupoSelect_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("Tem certeza que deseja excluir o(s) Grupo(s) selecionado(s)?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (string nomeArquivo in clbGrupoDeContado.CheckedItems)
                {
                    string caminhoArquivo = Path.Combine(Application.StartupPath, "Grupos", nomeArquivo + ".txt"); Path.Combine(Application.StartupPath, "Grupos", nomeArquivo + ".txt");

                    if (File.Exists(caminhoArquivo))
                    {
                        try
                        {
                            File.Delete(caminhoArquivo);
                            MessageBox.Show($"Arquivo '{nomeArquivo}' excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao excluir arquivo '{nomeArquivo}': {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Arquivo '{nomeArquivo}' não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                PreencherCheckListBoxComArquivos();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.sessao = tbSessionId.Text;
            Properties.Settings.Default.Save();
        }
    }
}