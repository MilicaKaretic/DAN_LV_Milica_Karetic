using DAN_LV_Milica_Karetic.Commands;
using DAN_LV_Milica_Karetic.Model;
using DAN_LV_Milica_Karetic.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace DAN_LV_Milica_Karetic.ViewModel
{
    class OrderViewModel : BaseViewModel
    {
        Order orderView;

        #region Constructors

        public OrderViewModel(Order orderOpen)
        {
            orderView = orderOpen;
            OrderPizza = new OrderPizza();
        }

        #endregion


        #region Properties

        private OrderPizza orderPizza;

        /// <summary>
        /// order pizza property
        /// </summary>
        public OrderPizza OrderPizza
        {
            get { return orderPizza; }
            set
            {
                orderPizza = value;
                OnPropertyChanged("OrderPizza");
            }
        }
        /// <summary>
        /// calculation info label
        /// </summary>
        private string labelInfo;
        public string LabelInfo
        {
            get
            {
                return labelInfo;
            }
            set
            {
                labelInfo = value;
                OnPropertyChanged("LabelInfo");
            }
        }

        //private ObservableCollection<string> _ingredients;
        //public ObservableCollection<string> Ingredients
        //{
        //    get { return _ingredients; ; }
        //    set
        //    {
        //        _ingredients = value;
        //        OnPropertyChanged("Ingredients");
        //    }
        //}


        //private string _name;
        //public string Name
        //{
        //    get { return _name; }
        //    set
        //    {
        //        _name = value;
        //        OnPropertyChanged("Name");
        //    }
        //}


        #endregion

        #region Commands

            /// <summary>
            /// save command
            /// </summary>
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private ICommand sendSMS;
        public ICommand SendSMS
        {
            get
            {
                if (sendSMS == null)
                {
                    sendSMS = new RelayCommand(param => SendSMSExecute(), param => CanSendSMSExecute());
                }
                return sendSMS;
            }
        }



        #endregion

        #region Functions

       /// <summary>
       /// save execute
       /// </summary>
        private void SaveExecute()
        {

            Random rnd = new Random();
            List<string> ingr = new List<string>();
            int totalAmount = 0;

            if (OrderPizza.Size == "small")
                totalAmount = 100;
            else if (OrderPizza.Size == "medium")
                totalAmount = 150;
            else if (OrderPizza.Size == "big")
                totalAmount = 180;

           
            if (OrderPizza.Cheese)
                ingr.Add("Cheese");
            else if (OrderPizza.Salami)
                ingr.Add("Salami");
            else if (OrderPizza.Ham)
                ingr.Add("Ham");
            else if (OrderPizza.Kulen)
                ingr.Add("Kulen");
            else if (OrderPizza.Olives)
                ingr.Add("Olives");
            else if (OrderPizza.Ketchup)
                ingr.Add("Ketchup");
            else if (OrderPizza.ChillyPepper)
                ingr.Add("ChillyPepper");
            else if (OrderPizza.Mayonnaise)
                ingr.Add("Mayonnaise");
            else if (OrderPizza.Oregano)
                ingr.Add("Oregano");
            else if (OrderPizza.Sesame)
                ingr.Add("Sesame");

            for (int i = 0; i < ingr.Count; i++)
            {
                int amount = rnd.Next(10, 100);
                totalAmount += amount;
            }

            LabelInfo = "Your amount is " + totalAmount + " RSD.";
            DisableButtons();

        }

        /// <summary>
        /// disable buttons after culculate amount
        /// </summary>
        private void DisableButtons()
        {
            orderView.cbBig.IsEnabled = false;
            orderView.cbmiddle.IsEnabled = false;
            orderView.cbsmall.IsEnabled = false;
            orderView.cSalami.IsEnabled = false;
            orderView.cHam.IsEnabled = false;
            orderView.cKulen.IsEnabled = false;
            orderView.cKetchup.IsEnabled = false;
            orderView.cMayonnaise.IsEnabled = false;
            orderView.cOlives.IsEnabled = false;
            orderView.cChillyPepper.IsEnabled = false;
            orderView.cCheese.IsEnabled = false;
            orderView.cOregano.IsEnabled = false;
            orderView.cSesame.IsEnabled = false;
            orderView.btnSave.IsEnabled = false;
        }

        /// <summary>
        /// can save execute
        /// </summary>
        /// <returns></returns>
        private bool CanSaveExecute()
        {

            return true;

        }

        /// <summary>
        /// send sms excute
        /// </summary>
        private void SendSMSExecute()
        {
            try
            {
                //string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
                string accountSid = "AC878e8b1a8493db3bfab83eb883369c3a";
                //string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
                string authToken = "c4a498867111886c7f5b13ea92257e51";
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber("+381611822834");
                var from = new PhoneNumber("+1 202 831 8982");

                var message = MessageResource.Create(
                    to: to,
                    from: from,
                    body: "Your pizza is ready");

                MessageBox.Show("Message successuflly sent.");
            }
            catch (Exception)
            {
                MessageBox.Show("Please provide valid token or phone number to send SMS.");

            }

            DisableButtons();

        }

        /// <summary>
        /// can send message after amount is calculated
        /// </summary>
        /// <returns></returns>
        private bool CanSendSMSExecute()
        {
            if (LabelInfo != null)
                return true;

                return false;
        }


        #endregion
    }
}
