﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FeroKGUI.MVVM.Model
{
    class ContactModel
    {
        public string Username { get; set; }
        public string ImageSource { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }
        public string LastMessage => Messages.Last().Message;
        public string Channel { get; set; }
    }
}
