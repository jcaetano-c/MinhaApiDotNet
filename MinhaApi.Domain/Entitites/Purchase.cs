using System;
using MinhaApi.Domain.Validations;

namespace MinhaApi.Domain.Entitites
{
	public class Purchase
	{
		public int Id { get; private set; }
		public int ProductId { get; private set; }
		public int PersonId { get; private set; }
		public DateTime Date { get; private set; }
		public Person Person { get; set; }
		public Product Product { get; set; }

		public Purchase(int productId, int personId, DateTime? date)
		{
			Validation(productId, personId, date);
			CreatePurchase(productId, personId, date);
		}
		public Purchase(int id, int productId, int personId, DateTime? date)
		{
			DomainValidationException.When(id < 0 || id == null, "Invalid Purchase ID.");
			Id = id;
			Validation(productId, personId, date);
			CreatePurchase(productId, personId, date);
		}
		private void Validation(int productId, int personId, DateTime? date)
		{
			DomainValidationException.When(productId < 0 || productId == null, "Invalid productId.");
			DomainValidationException.When(personId < 0 || personId == null, "Invalid personId.");
			DomainValidationException.When(!(date.HasValue), "No purchase date has been passed.");
		}

		private void CreatePurchase(int productId, int personId, DateTime? date)
		{
			ProductId = productId;
			PersonId = personId;
			if (date.HasValue)
				Date = date.Value;
			else
				Date = DateTime.Now;
		}

	}
}
