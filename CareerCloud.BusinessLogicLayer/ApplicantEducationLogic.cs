using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
	{
		public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
		{

		}
		public override void Add(ApplicantEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		public override void Update(ApplicantEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
		protected override void Verify(ApplicantEducationPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();


			foreach (var poco in pocos)
			{
				if(string.IsNullOrEmpty(poco.Major) || poco.Major.Length<3)
				{
					exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Id} Cannot be empty or less than 3 characters"));
				}
				if (poco.StartDate> DateTime.Now)
				{
					exceptions.Add(new ValidationException(108, $"StartDate for ApplicantEducation {poco.Id} Cannot be greater than today"));
				}
				if (poco.StartDate > poco.CompletionDate)
				{
					exceptions.Add(new ValidationException(109, $"CompletionDate for ApplicantEducation {poco.Id} cannot be earlier than StartDate"));
				}

			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
