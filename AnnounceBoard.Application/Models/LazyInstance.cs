using Microsoft.Extensions.DependencyInjection;

namespace AnnounceBoard.Application.Models;

public class LazyInstance<T>(IServiceProvider serviceProvider) : Lazy<T>(serviceProvider.GetRequiredService<T>());