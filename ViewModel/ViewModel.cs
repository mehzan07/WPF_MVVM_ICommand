using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
//Implementation of busness logic

namespace WPF_MVVM_ICommand.ViewModel
{
    
        class ViewModel : BindableBase
        {
            #region Properties  
            private string _userName;
            public string UserName
            {
                get { return _userName; }
                set { SetProperty(ref _userName, value); }
            }

            private string _age;
            public string Age
            {
                get { return _age; }
                set { SetProperty(ref _age, value); }
            }

            private string _emailId;
            public string EmailId
            {
                get { return _emailId; }
                set { SetProperty(ref _emailId, value); }
            }

            private bool _isButtonClicked;

            public bool IsButtonClicked
            {
                get { return _isButtonClicked; }
                set { SetProperty(ref _isButtonClicked, value); }
            }

            #endregion

            #region ICommands  
            public ICommand RegisterButtonClicked { get; set; }
            public ICommand ResetButtonClicked { get; set; }
            #endregion

            #region Constructor  
            public ViewModel()
            {
                RegisterButtonClicked = new RelayCommand(RegisterUser, CanUserRegister);
                ResetButtonClicked = new RelayCommand(ResetPage, CanResetPage);
            }
            #endregion

            #region Event Methods  
            private void RegisterUser(object value)
            {
                IsButtonClicked = true;
            }

            private bool CanUserRegister(object value)
            {

                if (string.IsNullOrEmpty(UserName))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            private void ResetPage(object value)
            {
                IsButtonClicked = false;
                UserName = Age = EmailId = "";
            }

            private bool CanResetPage(object value)
            {
                if (string.IsNullOrEmpty(UserName)
                    || string.IsNullOrEmpty(EmailId)
                    || string.IsNullOrEmpty(Age))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            #endregion
        }
    }
