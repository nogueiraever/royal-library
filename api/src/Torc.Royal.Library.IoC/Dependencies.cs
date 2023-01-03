using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Torc.Royal.Library.Application.Books;
using Torc.Royal.Library.Data;

namespace Torc.Royal.Library.IoC
{
    public static class Dependencies
    {
        public static void RegisterServiceDependencies(this IServiceCollection services)
        {
            services.TryAddScoped<IBookRepository, BookRepository>();
            services.TryAddScoped<IListBooksByAuthorUseCase, ListBooksByAuthorUseCase>();
            services.TryAddScoped<IListBooksByISBNUseCase, ListBooksByISBNUseCase>();
            services.TryAddScoped<IListOwnedBooksByUserUseCase, ListOwnedBooksByUserUseCase>();
            services.TryAddScoped<IListLovedBooksByUserUseCase, ListLovedBooksByUserUseCase>();
            services.TryAddScoped<IListWantToReadBooksByUserUseCase, ListWantToReadBooksByUserUseCase>();
        }
    }
}