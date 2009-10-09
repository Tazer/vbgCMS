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
			//Do this becuse it tries to find validators for types like string. Needs a better solution.
			if (!type.IsSubclassOf(typeof(BaseEntity)))
				return null;

			var serviceType = typeof(IValidator<>).MakeGenericType(new Type[] { type });

			return (IValidator)ObjectFactory.GetInstance(serviceType);
		}

		public IValidator<T> GetValidator<T>()
		{
			//return (IValidator<T>)GetValidator(typeof(T));

			//Do this becuse it tries to find validators for types like string. Needs a better solution.
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				return null;

			return ObjectFactory.GetInstance<IValidator<T>>();
		}

		#endregion
	}
}
