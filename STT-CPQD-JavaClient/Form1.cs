using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Ini;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Google.Cloud.Speech.V1;

namespace STT_CPQD_JavaClient
{
    public partial class Form1 : Form
    {
        public static string dir;
        public static string arquivo_ini;
        public static string comando;
        public static string arquivo_audio;
        public static string login;
        public static string path;
        public static string arquivo_texto;



        public Form1()
        {
            InitializeComponent();

        }

        private void btnTranscrever_Click(object sender, EventArgs e)
        {
            string result = "";
            string erro = "";
            string argumento = " " + comando + " " + arquivo_audio + " " + login;

            ProcessStartInfo processo = new ProcessStartInfo("java.exe");
            processo.WorkingDirectory = @"c:\client-asr";
            processo.Arguments = argumento;
            //processo.Arguments = @"-cp recognizer-examples-2.0.2.jar br.com.cpqd.asr.recognizer.example.BatchRecognizer wss://speech.cpqd.com.br/asr/ws/v2/recognize/8k builtin:slm/general c:/client-asr/teste.wav intelliway intelliway";
            processo.UseShellExecute = false;
            processo.RedirectStandardOutput = true;
            processo.RedirectStandardError = true;
            //processo.RedirectStandardInput = true;
            processo.CreateNoWindow = true;
            lblStatus.Text = "Processando...";
            lblStatus.Refresh();
            var thread = Process.Start(processo);
            thread.WaitForExit();

            //thread.StandardInput.WriteLine(@"cd /");
            //thread.StandardInput.WriteLine(@"cd client-asr");
            //thread.StandardInput.WriteLine(@"cls");
            //thread.StandardInput.WriteLine(@"java -cp recognizer-examples-2.0.2.jar br.com.cpqd.asr.recognizer.example.BatchRecognizer wss://speech.cpqd.com.br/asr/ws/v2/recognize/8k builtin:slm/general c:/client-asr/teste.wav intelliway intelliway");
            //thread.StandardInput.WriteLine("exit");
            result = thread.StandardOutput.ReadToEnd();
            erro = thread.StandardError.ReadToEnd();

            System.Threading.Thread.Sleep(500);

            txtResultado.Text = result;
            lblStatus.Text = "Finalizado";

            txtResultado.Text += "\n Erros: " + erro;



        }

        private void btnTranscreverAsync_Click(object sender, EventArgs e)
        {
            string argumento = " " + comando + " " + arquivo_audio + " " + login;
            Console.WriteLine(argumento);
            //MessageBox.Show(argumento);
            txtResultado.Text = "";
            //lblStatus.Text = "Prcessando...";
            Process p = new Process();
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = @"java";
            //p.WorkingDirectory = @"c:\client-asr";
            //p.StartInfo.Arguments = @"-cp c:\client-asr\recognizer-examples-2.0.2.jar br.com.cpqd.asr.recognizer.example.BatchRecognizer wss://speech.cpqd.com.br/asr/ws/v2/recognize/8k builtin:slm/general c:/client-asr/teste.wav intelliway intelliway";
            p.StartInfo.Arguments = argumento;


            try
            {
                p.OutputDataReceived += new DataReceivedEventHandler(
                (s, ev) =>
                {
                    txtResultado.Invoke(new Action(() => txtResultado.Text += "\n" + ev.Data));
                    //txtResultado.AppendText((ev.Data));
                }
            );
            }
            catch (Exception err)
            {
                txtResultado.AppendText(err.ToString());

            }


            try
            {
                p.ErrorDataReceived += new DataReceivedEventHandler((s, ev) =>
                { txtResultado.Invoke(new Action(() => txtResultado.Text += "\n" + ev.Data)); });
            }
            catch (Exception err)
            {
                txtResultado.AppendText(err.ToString());
            }


            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            lblStatus.Text = "Processamento Assíncrono";


        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Arquivos WAV | *.wav";
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    arquivo_texto = file;
                    txtArquivo.Text = file.Replace(@"\", "/");
                    arquivo_audio = txtArquivo.Text;
                }
                catch (IOException)
                {
                    MessageBox.Show("Erro ao localizar arquivo.");
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string descricao = File.ReadAllText(arquivo_texto + ".txt");
            //MessageBox.Show(descricao);

            AddChamado(descricao);


        }


        private async void AddChamado(string descricaochamado)
        {
            var URI = "http://localhost:3000/chamados";
            URI = "https://hmgsos.aguiabranca.com.br/ASKRest/v1/requisicoes/abrir";



            //definindo ANTE
            ANTE novoAnte = new ANTE();
            novoAnte.idParticipante = 21542;
            novoAnte.idTipoPapel = 1;

            //definindo Papeis
            Papeis novoPapel = new Papeis();
            novoPapel.ANTE = novoAnte;

            //definindo DadosBasicos
            DadosBasicos novosDadosBasicos = new DadosBasicos();
            novosDadosBasicos.Assunto = "Nova Denúncia - Canal de Denúncias";
            novosDadosBasicos.Descricao = descricaochamado;
            novosDadosBasicos.DescricaoOrigem = "Robo - Canal de Denuncia";
            novosDadosBasicos.Atividade = 11828;


            //definindo Conjuntos
            Conjuntos novoConjunto = new Conjuntos();
            novoConjunto.DadosBasicos = novosDadosBasicos;
            novoConjunto.Papeis = novoPapel;

            //definindo Chamado
            Chamado novoChamado = new Chamado();
            novoChamado.Formulario = 159;
            novoChamado.Conjuntos = novoConjunto;

            var Baerer = "Bearer gAAAAKbpfV-oyV63J_b32vUyjaMVN7sEABdqCgwBQEnYuKsQGHJVPLpbEemCKe0I-g75mo_GHcHJRX1pPCXxIN9gQpVOvoQW6k0zz2hXrYMBIV6pQjfI39RXh2fipL8vWzUiBM1x7CHXohKN9c9DTBx-T5gIvcEFgLolQ5sZE8uErnfCFAEAAIAAAAB8H7R0KEbI7SGk5VOX0idDKDZdzfJ4uAvSZJJHF2SrGGilbaMlOihfX4H7dzR_0JV1PiAqDYMaqa7PuTBI9el251_A6NDzTNJumKYbxMjsZVo6i3nTcOGKap8UQmPHRks9R2a1tqiytQaxd1qvFdUhXgSa-xsBKiYZKZfT6N_teyjkxg2a6etlOAvy0IPGH8K2PYh-aXVTL3GCG6KfNcNIQYwGDuWM3wM7zIhsOSrQj8F3sEZxNxh6HhiKeTB0NjeM42NvY5otlsRyrClabtHP6hweUS1vl2ZVhbJSG9TcJRiIOPHjYAgEL3bmMP4s2JQEPQT0qBMzVMbe6NqIJZWSPaIuoAkAyTtXTe9WxnRTkg";



            try
            {
                using (var client = new HttpClient())
                {
                    //var Bearer = "Bearer gAAAAKbpfV-oyV63J_b32vUyjaMVN7sEABdqCgwBQEnYuKsQGHJVPLpbEemCKe0I-g75mo_GHcHJRX1pPCXxIN9gQpVOvoQW6k0zz2hXrYMBIV6pQjfI39RXh2fipL8vWzUiBM1x7CHXohKN9c9DTBx-T5gIvcEFgLolQ5sZE8uErnfCFAEAAIAAAAB8H7R0KEbI7SGk5VOX0idDKDZdzfJ4uAvSZJJHF2SrGGilbaMlOihfX4H7dzR_0JV1PiAqDYMaqa7PuTBI9el251_A6NDzTNJumKYbxMjsZVo6i3nTcOGKap8UQmPHRks9R2a1tqiytQaxd1qvFdUhXgSa-xsBKiYZKZfT6N_teyjkxg2a6etlOAvy0IPGH8K2PYh-aXVTL3GCG6KfNcNIQYwGDuWM3wM7zIhsOSrQj8F3sEZxNxh6HhiKeTB0NjeM42NvY5otlsRyrClabtHP6hweUS1vl2ZVhbJSG9TcJRiIOPHjYAgEL3bmMP4s2JQEPQT0qBMzVMbe6NqIJZWSPaIuoAkAyTtXTe9WxnRTkg";
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer gAAAAKbpfV-oyV63J_b32vUyjaMVN7sEABdqCgwBQEnYuKsQGHJVPLpbEemCKe0I-g75mo_GHcHJRX1pPCXxIN9gQpVOvoQW6k0zz2hXrYMBIV6pQjfI39RXh2fipL8vWzUiBM1x7CHXohKN9c9DTBx-T5gIvcEFgLolQ5sZE8uErnfCFAEAAIAAAAB8H7R0KEbI7SGk5VOX0idDKDZdzfJ4uAvSZJJHF2SrGGilbaMlOihfX4H7dzR_0JV1PiAqDYMaqa7PuTBI9el251_A6NDzTNJumKYbxMjsZVo6i3nTcOGKap8UQmPHRks9R2a1tqiytQaxd1qvFdUhXgSa-xsBKiYZKZfT6N_teyjkxg2a6etlOAvy0IPGH8K2PYh-aXVTL3GCG6KfNcNIQYwGDuWM3wM7zIhsOSrQj8F3sEZxNxh6HhiKeTB0NjeM42NvY5otlsRyrClabtHP6hweUS1vl2ZVhbJSG9TcJRiIOPHjYAgEL3bmMP4s2JQEPQT0qBMzVMbe6NqIJZWSPaIuoAkAyTtXTe9WxnRTkg");
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",Bearer);
                    var serializedProduto = JsonConvert.SerializeObject(novoChamado);
                    var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(URI, content);
                }

                MessageBox.Show("Chamado aberto com sucesso");
            }

            catch (Exception e)
            {
                MessageBox.Show("Erro ao abrir chamado");
                MessageBox.Show(e.ToString());
            }





        }




        private void validaIni()
        {
            bool valida_ini = true;

            if (!(File.Exists(arquivo_ini))) //alerta a falta do arquivo.ini
            {

                valida_ini = false;
                MessageBox.Show("Erro - Arquivo de configuração não encontrado!");
                Application.Exit();

            }
            else
            {
                Console.WriteLine(DateTime.Now.ToString() + " - Arquivo INI encontrado - SUCESSO");
                valida_ini = true;
                carregaVar();
            }

        }

        private void carregaVar()
        {
            IniFile ini = new IniFile(arquivo_ini);
            comando = ini.IniReadValue("geral", "comando");
            login = ini.IniReadValue("geral", "login");
            path = ini.IniReadValue("geral", "path");
            arquivo_audio = ini.IniReadValue("geral", "arquivo");
            txtArquivo.Text = ini.IniReadValue("geral", "arquivo");
            arquivo_texto = txtArquivo.Text.Replace(@"/", @"\");
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "google-service.json");

            txtArquivo.Text = "";
            txtResultado.Text = "";
            txtDiretorio.Text = @"c:\client-asr";
            dir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            arquivo_ini = dir + @"\config.ini";
            validaIni();


        }

        private void btnSelDir_Click(object sender, EventArgs e)
        {
            string[] pdfFiles = Directory.GetFiles(@"C:\Users\Dell\Documents", "*.pdf")
                                     .Select(Path.GetFileName)
                                     .ToArray();

            foreach (var item in pdfFiles)
            {
                MessageBox.Show(item.ToString());
            }


        }

        private void btnAbrirDiretorio_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    txtDiretorio.Text = fbd.SelectedPath;
                    btnTrascLote.Enabled = true;


                }
            }
        }


        private void quebraAudio(string arquivo)
        {
            //criando a pasta temp
            string current_dir = Directory.GetCurrentDirectory().ToString();
            Directory.CreateDirectory("./temp");
            
            //MessageBox.Show(Directory.GetCurrentDirectory().ToString());

            //vai pegar o arquivo e quebrar em vários arquivos de 50 segundos e salvar o resultado na pasta temp
            //usando o utilitário ffmpeg

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"ffmpeg.exe",
                    Arguments = "-i " + arquivo + " -f segment -segment_time 50 -c copy \""+current_dir+"\\temp\\out%03d.wav\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    CreateNoWindow = false,
                    //WorkingDirectory = @"C:\MyAndroidApp\"
                }
            };


            
            proc.Start();

            //espera 2 segundos
            System.Threading.Thread.Sleep(2000);


        }

        private int duracaoAudio(string arquivo)
        {
            var bitrate = 0;
            var duration = 0;

            byte[] TotalBytes = File.ReadAllBytes(arquivo);
            bitrate = (BitConverter.ToInt32(new[] { TotalBytes[28], TotalBytes[29], TotalBytes[30], TotalBytes[31] }, 0) * 8);
            duration = (TotalBytes.Length - 8) * 8 / bitrate;
            return duration;
            //textBox1.Text = duration.ToString();
        }

        private void btnTrascLote_Click(object sender, EventArgs e)
        {
            string[] pdfFiles = Directory.GetFiles(txtDiretorio.Text, "*.wav")
                                     .Select(Path.GetFileName)
                                     .ToArray();




            txtResultado.Text = "";



            txtResultado.Text += "Encontrados " + pdfFiles.Length + " arquivos!" + "\r\n\r\n";

            foreach (var item in pdfFiles)
            {

                string erro = "0";
                txtResultado.Text += "Iniciando processamento do arquivo " + txtDiretorio.Text + @"\" + item + "\r\n";
                txtResultado.Refresh();

                string argumento = " " + comando + " " + txtDiretorio.Text.Replace(@"\", @"/") + @"/" + item + " " + login;
                Console.WriteLine(argumento);

                ProcessStartInfo processo = new ProcessStartInfo("java.exe");
                processo.WorkingDirectory = @"c:\client-asr";
                processo.Arguments = argumento;
                //processo.Arguments = @"-cp c:\client-asr\recognizer-examples-2.0.2.jar br.com.cpqd.asr.recognizer.example.BatchRecognizer wss://speech.cpqd.com.br/asr/ws/v2/recognize/8k builtin:slm/general c:/client-asr/" + item+" intelliway intelliway";
                processo.UseShellExecute = false;
                //processo.RedirectStandardOutput = false;
                //processo.RedirectStandardError = true;
                //processo.RedirectStandardInput = true;
                //processo.CreateNoWindow = true;
                lblStatus.Text = "Processando...";
                lblStatus.Refresh();
                var thread = Process.Start(processo);
                thread.WaitForExit();
                try
                {
                    thread.Kill();
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.ToString());
                }

                try
                {
                    erro = thread.StandardError.ReadToEnd();
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.ToString());
                }



                if (erro != "0")
                {
                    txtResultado.Text += "Erros encontrado!\r\n";
                }

                txtResultado.Text += "Finalizado processamento do arquivo " + item + "\r\n\r\n";
                txtResultado.Refresh();




                System.Threading.Thread.Sleep(500);





            }

            lblStatus.Text = "Finalizado";


        }

        private string transcreve_simples_sync(string arquivo)
        {
            var output_simples = "";

            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.EncodingUnspecified,
                SampleRateHertz = 8000,
                LanguageCode = "pt-br",
            }, RecognitionAudio.FromFile(arquivo));



            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    output_simples = output_simples + " " + alternative.Transcript;

                }
            }

            if (output_simples.Length == 0) output_simples = "Sem info";

            return output_simples;

        }

        private void btnTranscLoteGs1_Click(object sender, EventArgs e)
        {

            //string que vai receber o resultaod da transcricão
            string output = "";

            //varrendo o diretório pesquisando os arquivos e guardando no vetor
            string[] audioFiles = Directory.GetFiles(txtDiretorio.Text, "*.wav")
                         .Select(Path.GetFileName)
                         .ToArray();




            txtResultado.Text = "";



            txtResultado.Text += "Encontrados " + audioFiles.Length + " arquivos!" + "\r\n\r\n";
            txtResultado.Refresh();

            foreach (var item in audioFiles)
            {

                
                string erro = "0";
                string caminho_arquivo = txtDiretorio.Text + @"\" + item;
                txtResultado.Text += "Iniciando processamento do arquivo " + txtDiretorio.Text + @"\" + item + "\r\n";
                txtResultado.Refresh();

                if (duracaoAudio(caminho_arquivo) > 59) //se a duração do arquivo de audio for maior que 58 segundos
                {
                    txtResultado.Text += "Audio com duração maior que 1 minuto - Processamento será divido em partes \r\n";
                    txtResultado.Refresh();

                    //Quebrando em vários arquivos.wav de 50 segundos
                    //quebraAudio(caminho_arquivo);

                    //inserindo o resultado (vários arquivos quebrados) do quebra áudio em um vetor
                    string[] wavFiles = Directory.GetFiles("./temp", "*.wav")
                                     .Select(Path.GetFileName)
                                     .ToArray();


                    txtResultado.Text += "Quebrando em "+wavFiles.Length+" partes! \r\n";
                    txtResultado.Refresh();

                    var cont_partes = 0;

                    //fazendo a transcrição de cada um dos arquivos quebrados
                    foreach (var item_temp in wavFiles)
                    {
                        cont_partes++;
                        txtResultado.Text += "Transcrevendo parte "+cont_partes+"\r\n";
                        txtResultado.Refresh();
                        output += transcreve_simples_sync(@"./temp/" + item_temp);
                        txtResultado.Text += "Fim da parte " + cont_partes + "\r\n";
                        txtResultado.Refresh();

                        //jogando o scroll do textbox pro fim
                        txtResultado.SelectionStart = txtResultado.Text.Length;
                        txtResultado.ScrollToCaret();
                        txtResultado.Refresh();

                    }


                    //apagando diretorio temp

                    var dir = new DirectoryInfo("./temp");
                    dir.Delete(true);



                }

                else //se for menor que 59 segundos
                {
                    txtResultado.Text += "Audio com duração menor que 1 minuto - Processamento Direto \r\n";
                    txtResultado.Refresh();
                    output = transcreve_simples_sync(caminho_arquivo);
                }

                txtResultado.Text += "Salvando resultado em: "+caminho_arquivo+ ".txt  \r\n";
                txtResultado.Refresh();
                File.WriteAllText(caminho_arquivo+".txt", output);

                //zerando output após gravar arquivo
                output = "";

                txtResultado.Text += "Finalizado processamento do arquivo " + item + "\r\n\r\n";
                txtResultado.Refresh();

                //jogando o scrolll do textbox pro final
                txtResultado.SelectionStart = txtResultado.Text.Length;
                txtResultado.ScrollToCaret();
                txtResultado.Refresh();

            }


            
            lblStatus.Text = "Finalizado";
            System.Threading.Thread.Sleep(500);

            

        }




    }



}
