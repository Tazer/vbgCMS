using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Mvc;

namespace vbgCMS.UI.Web.Code.Configuration.Mvc
{
    public class RegisterModelBinder : IRegister
    {
        private readonly ModelBinderDictionary _modelbinders;
        private readonly IValidatorFactory _validationFactory;

        public RegisterModelBinder(ModelBinderDictionary modelbinders, IValidatorFactory validationFactory)
        {
            _modelbinders = modelbinders;
            _validationFactory = validationFactory;
        }

        #region IRegister Members

        public void Execute()
        {
            _modelbinders.DefaultBinder = new FluentValidationModelBinder(_validationFactory);
        }

        #endregion
    }
}
