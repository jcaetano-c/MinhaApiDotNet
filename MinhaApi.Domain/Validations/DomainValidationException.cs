using System;

namespace MinhaApi.Domain.Validations
{
	public class DomainValidationException : Exception
	{
		public DomainValidationException(string error)
		: base(error)
		{
		}

		public static void When(bool hasError, string errorMessage)
		{
			if (hasError)
				throw new DomainValidationException(errorMessage);
		}
	}
}
