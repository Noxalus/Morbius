﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace Wpf_Morbius.ViewModel
{
    public class FirstViewModel : BaseViewModel
    {
        #region Commandes
        public ICommand ClickCommand { get; set; }
        #endregion

        /// <summary>
        /// constructeur
        /// </summary>
        public FirstViewModel()
        {
            ClickCommand = new RelayCommand(param => Click(), param => true);
        }

        /// <summary>
        /// réponse à la commande click
        /// </summary>
        private void Click()
        {

        }
    }
}
