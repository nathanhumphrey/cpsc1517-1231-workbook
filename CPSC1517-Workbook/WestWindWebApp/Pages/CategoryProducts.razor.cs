using Microsoft.AspNetCore.Components;

// Required system namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages
{
	public partial class CategoryProducts
	{
		// Need the BLL services
		[Inject]
		CategoryServices CategoryServices { get; set; }
		[Inject]
		ProductServices ProductServices { get; set; }

		// Need navigation manager to update the address URL
		[Inject]
		NavigationManager NavigationManager { get; set; }

		// Required component properties
		public List<Category>? Categories { get; set; } = null;
		public List<Product>? Products { get; set; } = null;

		// Define as a parameter so we can read it from the address URL, if present
		[Parameter]
		public string? CategoryId { get; set; } = null;

		protected override void OnInitialized()
		{
			Categories = CategoryServices.GetAllCategories();

			// Check for category id in the URL
			if (CategoryId != null)
			{
				Products = ProductServices.GetProductsByCategoryId(int.Parse(CategoryId));
			}

			base.OnInitialized();
		}

		// Load the products for the selected category and update the address URL
		private void HandleCategorySelected()
		{
			if (CategoryId != null)
			{
				Products = ProductServices.GetProductsByCategoryId(int.Parse(CategoryId));
				NavigationManager.NavigateTo($"/category-products/{CategoryId}");
			}
		}
	}
}
