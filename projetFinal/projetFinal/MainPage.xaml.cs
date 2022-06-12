using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace projetFinal
{
    public partial class MainPage : ContentPage
    {
        List<List<string>> mvt = new List<List<string>>(); //création d'une sous liste de trajet
        List<string> Data = new List<string>(); //liste

        bool animationInProgress = false; 
        Stopwatch stopwatch = new Stopwatch(); //déterminer le temps d’exécution 

        public MainPage()
        {
            InitializeComponent();
            if (Connectivity.NetworkAccess != NetworkAccess.Internet) //afficher une alerte pas de réseau si il nya pas d'acces réseau
            {
             DisplayAlert("Pas de réseau", "", "OK");
            }

            if (choixauto.IsChecked == true) // bouton manuelle invisible par defaut 
            {   //bouton manuelle 
                text_manuel.IsVisible = false;
                TR.IsVisible = false;
                TR1.IsVisible = false;
                LE.IsVisible = false;
                BE.IsVisible = false;
                PC.IsVisible = false;
                DC.IsVisible = false;
                TM.IsVisible = false;
                TM1.IsVisible = false;
                TP.IsVisible = false;
                TP1.IsVisible = false;
                SP.IsVisible = false;
                LP.IsVisible = false;
                RD.IsVisible = false;
                texteinfo.IsVisible = true;
            }
           
        }
            
        protected override void OnAppearing() //apparition d'acces au réseau
        {
            base.OnAppearing();
            
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }
    /*   protected override void OnDisappearing() disparition d'acces au réseau
        {
            base.OnDisappearing();
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }*/

        private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e) //changement d'état de réseau
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet) //modifier la notif qnd tu peux
            {
                    await DisplayAlert("Pas de réseau",  $" {e.NetworkAccess}","OK");
            }
        }

            public void Connect(String server, String message) //communication serveur-client avec le pc 
        {
            try
            {
                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port); //connecter au serveur

                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);// Envoyer le message au TcpServer connecté

                data = new Byte[256];String responseData = String.Empty; //récuperer le message recu

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes); 

            //    message_server.Text = responseData; //afficher dans l'interface

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {}
        }
        
                                                    //les boutons clicked & pressed 
        //bouton automatique 
        void tournerd_auto(object sender, EventArgs e) {  Data.Add("0\n");  }
        async void tournerg_auto(object sender, EventArgs e){ Data.Add("2\n");  }
        async void leverep_auto(object sender, EventArgs e){ Data.Add("3\n"); }
        async void baisserep_auto(object sender, EventArgs e) { Data.Add("4\n"); }
        async void pliercoude_auto(object sender, EventArgs e) { Data.Add("5\n");}
        async void depliercoude_auto(object sender, EventArgs e) { Data.Add("6\n");}
        async void monterpoigne_auto(object sender, EventArgs e) { Data.Add("7\n"); }
        async void baisserpoigne_auto(object sender, EventArgs e) { Data.Add("8\n"); }
        async void tournerdpince_auto(object sender, EventArgs e) { Data.Add("9\n");}
        async void tournergpince_auto(object sender, EventArgs e) { Data.Add("m\n"); }
        async void saisirpince_auto(object sender, EventArgs e) { Data.Add("n\n"); }
        async void lacherpince_auto(object sender, EventArgs e) { Data.Add("o\n"); }

        // bouton manuel 
        async void Button_tournerobot(object sender, EventArgs e) //envoi de message au serveur lorsque le bouton est pressé
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {   
                Connect("192.168.1.101", "a"); 
               // Console.WriteLine("Pressed");
                return animationInProgress;
            });
        }
        async void Button_tournerobot1(object sender, EventArgs e) 
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "b"); 
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });
  
        }
        async void Button_monter_epaule(object sender, EventArgs e) 
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "c");
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });
          
        }
        async void Button_baisser_epaule(object sender, EventArgs e)  
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "d");
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });

        }
        async void Button_plier_coude(object sender, EventArgs e)  
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "e");
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });

        }
        async void Button_deplier_coude(object sender, EventArgs e) 
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "f");
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });

        }
        async void Button_tourner_poignee(object sender, EventArgs e)
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "g"); 
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });
        }
        async void Button_tourner_poignee1(object sender, EventArgs e)
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "h"); 
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });
        }
        async void Button_tourner_pince(object sender, EventArgs e) 
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                 Connect("192.168.1.101", "i");   
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });

        }
        async void Button_tourner_pince1(object sender, EventArgs e)
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "j");
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });

        }
        async void Button_saisir_pince(object sender, EventArgs e) 
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "k"); 
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });

        }
        async void Button_lacher_pince1(object sender, EventArgs e) 
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(80), () =>
            {
                Connect("192.168.1.101", "l"); 
                //Console.WriteLine("Pressed");
                return animationInProgress;
            });

        }
        private void Button_released(object sender, EventArgs e) //bouton relacher pour arreter l'envoi de message
        {
            animationInProgress = false;
            stopwatch.Stop();
            //Console.WriteLine("Released");
        }


        async void Button_automatique(object sender, EventArgs e) //bouton de confirmation
        {

            bool response = await DisplayAlert("Validez-vous cette trajectoire ?", "", "valider", "annuler");
            {
                if (response)
                {
                        mvt.Add(Data);
                    foreach (var list in mvt) //parcourt la liste un par un
                    {
                        foreach (var element in list)
                        {
                            //envoyer les mouvements choisi sur les boutons-images un par un

                            if (element == "0\n") {/* Console.WriteLine("0");*/Connect("192.168.1.101", "0"); }
                            if (element == "2\n") { /*Console.WriteLine("2");*/Connect("192.168.1.101", "2"); }
                            if (element == "3\n") { /*Console.WriteLine("3");*/Connect("192.168.1.101", "3"); }
                            if (element == "4\n") { /*Console.WriteLine("4");*/Connect("192.168.1.101", "4"); }
                            if (element == "5\n") { /*Console.WriteLine("5");*/Connect("192.168.1.101", "5"); }
                            if (element == "6\n") { /*Console.WriteLine("6");*/Connect("192.168.1.101", "6"); }
                            if (element == "7\n") { /*Console.WriteLine("7");*/Connect("192.168.1.101", "7"); }
                            if (element == "8\n") { /*Console.WriteLine("8");*/Connect("192.168.1.101", "8"); }
                            if (element == "9\n") { /*Console.WriteLine("9");*/Connect("192.168.1.101", "9"); }
                            if (element == "m\n") { /*Console.WriteLine("m");*/Connect("192.168.1.101", "m"); }
                            if (element == "n\n") { /*Console.WriteLine("n");*/Connect("192.168.1.101", "n"); }
                            if (element == "o\n") { /*Console.WriteLine("o");*/Connect("192.168.1.101", "o"); }   
                        }
                        Console.WriteLine();
                        Data.Clear();
                    }
                }
            }
        }
        async void Button_supprime(object sender, EventArgs e) //bouton de supprimation de trajet
        { 
            Data.Clear();
        }
            void mode_manuelle_checked(object sender, CheckedChangedEventArgs e) //mode manuel
        {   
            //bouton manuelle
                                             // rend visible bouton manuel
            text_manuel.IsVisible = true; 
            TR.IsVisible = true;    
            TR1.IsVisible = true;
            LE.IsVisible = true;
            BE.IsVisible = true;
            PC.IsVisible = true;
            DC.IsVisible = true;
            TM.IsVisible = true;
            TP.IsVisible = true;
            TM1.IsVisible = true;
            TP1.IsVisible = true;
            SP.IsVisible = true;
            LP.IsVisible = true;
            RD.IsVisible = true;
            texteinfo.IsVisible = false;

            //bouton automatique               rend non clickable le bouton auto
            TR_a.IsEnabled = false;
            TR_a1.IsEnabled = false;
            LE_a.IsEnabled = false;
            BE_a.IsEnabled = false;
            PC_a.IsEnabled = false;
            DC_a.IsEnabled = false;
            TM_a.IsEnabled = false;
            TP_a.IsEnabled = false;
            TM_a1.IsEnabled = false;
            TP_a1.IsEnabled = false;
            SP_a.IsEnabled = false;
            LP_a.IsEnabled = false;
            Valide.IsEnabled = false; 
            Supprime.IsEnabled = false;
        }
        void mode_auto_checked(object sender, CheckedChangedEventArgs e) //mode automatique
        {   //envoi message auto   
            //bouton manuelle
            text_manuel.IsVisible = false;
            TR.IsVisible = false;   // le rend invisible
            TR1.IsVisible = false;
            LE.IsVisible = false;
            BE.IsVisible = false;
            PC.IsVisible = false;
            DC.IsVisible = false;
            TM.IsVisible = false;
            TM1.IsVisible = false;
            TP.IsVisible = false;
            TP1.IsVisible = false;
            SP.IsVisible = false;
            LP.IsVisible = false;
            RD.IsVisible = false;
            texteinfo.IsVisible = true;

            //bouton auto
            TR_a.IsEnabled = true;      //le rend clickable
            TR_a1.IsEnabled = true;
            LE_a.IsEnabled = true;
            BE_a.IsEnabled = true;
            PC_a.IsEnabled = true;
            DC_a.IsEnabled = true;
            TM_a.IsEnabled = true;
            TP_a.IsEnabled = true;
            TM_a1.IsEnabled = true;
            TP_a1.IsEnabled = true;
            SP_a.IsEnabled = true;
            LP_a.IsEnabled = true;

            Valide.IsEnabled = true;
            Supprime.IsEnabled=true;

        }
    }

}  