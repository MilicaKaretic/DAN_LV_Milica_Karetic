﻿using DAN_LV_Milica_Karetic.Commands;
using DAN_LV_Milica_Karetic.Model;
using DAN_LV_Milica_Karetic.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        /// Login info label
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

        

        #endregion

        #region Functions



        private void SaveExecute()
        {

            Random rnd = new Random();
            List<string> ingr = new List<string>();
            int totalAmount = 0;

            if (OrderPizza.Size == "small")
                totalAmount = 100;
            else if (OrderPizza.Size == "middle")
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

            LabelInfo = "Your bill is " + totalAmount + " RSD.";           

        }

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
        }

        private bool CanSaveExecute()
        {

            return true;

        }

       

        #endregion
    }
}