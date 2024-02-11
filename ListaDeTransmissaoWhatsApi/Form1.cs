using ListaDeTransmissaoWhatsApi.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ListaDeTransmissaoWhatsApi
{
    public partial class Form1 : Form
    {
        public string sessionId;
        public string host = "http://191.220.2.201:3000";
        public Form1()
        {
            InitializeComponent();
            sessionId = tbSessionId.Text;
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
                    while (checkImg)
                    {
                        response = await RequestRestGetAsync($"/session/qr/", "/Image", "image/png");
                        //responseData = JsonConvert.DeserializeObject<StartSession>(response.Content);
                        if (response.ContentType != "image/png")
                        {
                            Thread.Sleep(1000);
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
            request.AddHeader("Content-Type", contentType);
            return await client.ExecuteAsync(request);
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


            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Campo_Leave(object sender, EventArgs e)
        {
            TextBox campo = sender as TextBox;
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


    }
}