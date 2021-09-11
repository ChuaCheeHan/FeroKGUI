using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FeroKGUI.MVVM.Model;
using FeroKGUI.Core;
using System.Windows;
using Microsoft.Maps.MapControl.WPF;
using System.Net.Http;

namespace FeroKGUI.MVVM.ViewModel
{
    class MainViewModel: ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /*Commands*/
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set 
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            ObservableCollection<MessageModel> Messages2 = new ObservableCollection<MessageModel>();
            List<ObservableCollection<MessageModel>> messageList = new List<ObservableCollection<MessageModel>>();

            Microsoft.Maps.MapControl.WPF.Map BingMaps = ((MainWindow)Application.Current.MainWindow).BingMaps;
            int counter = 0;
            foreach (Pushpin pin in BingMaps.Children)
            {
                messageList.Add(new ObservableCollection<MessageModel>());
                messageList[counter].Add(new MessageModel
                {
                    Username = "Admin",
                    UsernameColor = "#409aff",
                    ImageSource = "https://imgur.com/yMWvLXd.png",
                    Message = "Connection Established",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = true
                });

                Contacts.Add(new ContactModel
                {
                    Username = pin.ToolTip.ToString(),
                    ImageSource = "https://i.imgur.com/i2szTsp.png",
                    Messages = messageList[counter],
                    Channel = pin.Tag.ToString()
                });
                Console.WriteLine("Zipcode " + pin.Tag);
                counter++;
            }

            if (SelectedContact == null)
            {
                SelectedContact = Contacts[0];
            };


            SendCommand = new RelayCommand(o =>
            {
                if (SelectedContact == null) //Just in case
                {
                    SelectedContact = Contacts[0];
                };

                Console.WriteLine("Channel no: "+ SelectedContact.Channel);
                if (SelectedContact.Messages.Last().IsNativeOrigin == true)
                {
                    SelectedContact.Messages.Add(new MessageModel
                    {
                        Message = Message,
                        FirstMessage = false,
                        Time = DateTime.Now,
                        IsNativeOrigin = true,
                    });
                }
                else
                {
                    SelectedContact.Messages.Add(new MessageModel
                    {
                        Username = "Bunny",
                        UsernameColor = "#409aff",
                        ImageSource = "https://imgur.com/yMWvLXd.png",
                        Message = Message,
                        Time = DateTime.Now,
                        IsNativeOrigin = true,
                    });
                }

                Message = "";

                httpsend(SelectedContact);
            });

            /*
            Messages.Add(new MessageModel
            {
                Username = "Allison",
                UsernameColor = "#409aff",
                ImageSource = "https://imgur.com/yMWvLXd.png",
                Message="Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Allison",
                    UsernameColor = "#409aff",
                    ImageSource = "https://imgur.com/yMWvLXd.png",
                    Message="Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Bunny",
                    UsernameColor = "#409aff",
                    ImageSource = "https://imgur.com/yMWvLXd.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Bunny",
                UsernameColor = "#409aff",
                ImageSource = "https://imgur.com/yMWvLXd.png",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true,
            });


            for (int i = 0; i < 2; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Allison {i}",
                    ImageSource = "https://i.imgur.com/i2szTsp.png",
                    Messages = Messages
                });
            };


            
            Messages2.Add(new MessageModel
            {
                Username = "Benny",
                UsernameColor = "#409aff",
                ImageSource = "https://imgur.com/yMWvLXd.png",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });
            Contacts.Add(new ContactModel
            {
                Username = "Benny",
                ImageSource = "https://i.imgur.com/i2szTsp.png",
                Messages = Messages2
            });
            */

        }

        private void httpsend(ContactModel selectedContact)
        {
            string channel = selectedContact.Channel;
            string name = selectedContact.Username;
            string message = selectedContact.LastMessage;
            string ImageSource = selectedContact.ImageSource;

            HttpClient feroChat = new HttpClient();
            feroChat.BaseAddress = new Uri("https://ferochat.herokuapp.com/");

            var values = new Dictionary<string, string>
                {
                    { "channel", channel },
                    { "name", name },
                    { "message", message },
                    { "ImageSource", ImageSource }
                };

            var content = new FormUrlEncodedContent(values);
            var response = feroChat.PostAsync("https://ferochat.herokuapp.com/", content);
            response.Wait();
            var responseString = response.Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine("responseString: " + responseString);

            throw new NotImplementedException();
        }
    }
}
