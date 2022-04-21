using System;
using MinhaApi.Domain.Validations;

namespace MinhaApi.Domain.Entitites
{
	public sealed class Product
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string CodeErp { get; set; }

		public decimal Price { get; set; }
		public ICollection<Purchase> Purchases { get; set; }



		public Product(string name, string codeErp, decimal price)
		{
			Validation(name, codeErp, price);
			CreateProduct(name, codeErp, price);
		}

		public Product(int id, string name, string codeErp, decimal price)
		{
			DomainValidationException.When(id < 0 || id == null, "Invalid ID.");
			Id = id;
			Validation(name, codeErp, price);
			CreateProduct(name, codeErp, price);
		}

		private void Validation(string name, string codeErp, decimal price)
		{
			DomainValidationException.When(string.IsNullOrEmpty(name),
			"Product name must be passed.");
			DomainValidationException.When(string.IsNullOrEmpty(codeErp), "Product codeERP must be passed.");
			DomainValidationException.When(price < 0 || price == null,
			"Invalid product price.");
		}

		private void CreateProduct(string name, string codeErp, decimal price)
		{
			Name = name;
			CodeErp = codeErp;
			Price = price;
		}

	}
}
