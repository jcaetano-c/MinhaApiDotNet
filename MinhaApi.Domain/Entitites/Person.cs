using System;
using MinhaApi.Domain.Validations;

namespace MinhaApi.Domain.Entitites
{
	public sealed class Person
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Document { get; private set; }
		public string Phone { get; private set; }
		public ICollection<Purchase> Purchases { get; set; }



		public Person(string document, string name, string phone)
		{
			Validation(document, name, phone);
			CreatePerson(document, name, phone);
		}

		public Person(int id, string document, string name, string phone)
		{
			DomainValidationException.When(id < 0 || id == null, "Invalid ID.");
			Id = id;
			Validation(document, name, phone);
			CreatePerson(document, name, phone);
		}

		private void Validation(string document, string name, string phone)
		{
			DomainValidationException.When(string.IsNullOrEmpty(document), "Person Document must be passed.");
			DomainValidationException.When(string.IsNullOrEmpty(name), "Person Name must be passed.");
			DomainValidationException.When(string.IsNullOrEmpty(phone), "Person Phone must be passed.");
		}

		private void CreatePerson(string document, string name, string phone)
		{
			Document = document;
			Name = name;
			Phone = phone;
		}


	}
}
