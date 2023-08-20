using Expect.Registry.Domain.ViewModels.Interfaces;
using Expect.Registry.Infrastructure.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Expect.Registry.Infrastructure.Commands.FilterDocuments
{
	public class FilterDocumentsByNameQuery : IRequest<IEnumerable<IViewModel>>
	{
		public string Name { get; set; }
		public IEnumerable<IViewModel> Documents { get; set; }

		public FilterDocumentsByNameQuery(string name, IEnumerable<IViewModel> documents)
		{
			Name = name;
			Documents = documents;
		}
	}

	public class FilterDocumentsByNameQueryHandler : IRequestHandler<FilterDocumentsByNameQuery, IEnumerable<IViewModel>>
	{
		public Task<IEnumerable<IViewModel>> Handle(FilterDocumentsByNameQuery request, CancellationToken cancellationToken)
		{
			var pattern = $@"\b{request.Name}\b";

			var task = Task.FromResult(request.Documents
					.Where(doc => Regex.IsMatch(request.Name, pattern)));

			return task;
		}
	}
}
