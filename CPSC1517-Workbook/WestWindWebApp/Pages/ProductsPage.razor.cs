using Microsoft.AspNetCore.Components;

// Required system namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages
{
	public partial class ProductsPage
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
		public List<Category>? Categories { get; set; }
		public List<Product>? Products { get; set; }

		// Define as a parameter so we can read it from the address URL, if present
		[Parameter]
		public int CategoryId { get; set; }

		// Used for partial product name or category name search
		public string PartialSearch { get; set; }

		protected override void OnInitialized()
		{
			Categories = CategoryServices.GetAllCategories();

			// Check for category id in the URL
			if (CategoryId != 0)
			{
				Products = ProductServices.GetProductsByCategoryId(CategoryId);
				PartialSearch = null;
			}

			base.OnInitialized();
		}

		/// <summary>
		/// Load the products for the selected category and update the address URL
		/// </summary>
		private void HandleCategorySelected()
		{
			if (CategoryId != 0)
			{
				Products = ProductServices.GetProductsByCategoryId(CategoryId);
				PartialSearch = null;
				NavigationManager.NavigateTo($"/products/{CategoryId}");
			}
		}

		/// <summary>
		/// Load the products that match the partial search on product name or category name
		/// </summary>
		public void HandlePartialSearch()
		{
			if (!string.IsNullOrWhiteSpace(PartialSearch))
			{
				Products = ProductServices.GetProductsByNameOrCategoryName(PartialSearch);
				CategoryId = 0;
				NavigationManager.NavigateTo($"/products");
			}
		}
	}
}
