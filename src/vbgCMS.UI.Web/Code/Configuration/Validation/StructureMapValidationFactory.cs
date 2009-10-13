using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using StructureMap;
using vbgCMS.Infrastructure.Base;

namespace vbgCMS.UI.Web.Code.Configuration.Validation
{
	public class StructureMapValidationFactory : IValidatorFactory
	{
		#region IValidatorFactory Members

		public IValidator GetValidator(Type type)
		{
			var serviceType = typeof(IValidator<>).MakeGenericType(new Type[] { type });

			return (IValidator)ObjectFactory.TryGetInstance(serviceType);
		}

		public IValidator<T> GetValidator<T>()
		{
			return ObjectFactory.TryGetInstance<IValidator<T>>();
		}

		#endregion
	}
}
