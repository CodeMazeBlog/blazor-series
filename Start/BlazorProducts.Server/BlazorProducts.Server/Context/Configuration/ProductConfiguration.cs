using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Context.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
			builder.HasData
			(
				//Mugs
				new Product
				{
					Id = new Guid("0102F709-1DD7-40DE-AF3D-23598C6BBD1F"),
					Name = "Travel Mug",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1062161969.4889/mug,travel,x1000,center-pad,1000x1000,f8f8f8.u2.jpg",
					Price = 11
				},
				new Product
				{
					Id = new Guid("AC7DE2DC-049C-4328-AB06-6CDE3EBE8AA7"),
					Name = "Classic Mug",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1063377597.4889/ur,mug_lifestyle,square,1000x1000.u2.jpg",
					Price = 22
				},
				//Clothing
				new Product
				{
					Id = new Guid("D26384CB-64B9-4ACA-ACB0-4EBB8FC53BA2"),
					Name = "Code Maze Logo T-Shirt",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1063364659.4889/ra,vneck,x1900,101010:01c5ca27c6,front-c,160,70,1000,1000-bg,f8f8f8.u2.jpg",
					Price = 20
				},
				new Product
				{
					Id = new Guid("B47D4C3C-3E29-49B9-B6BE-28E5EE4625BE"),
					Name = "Pullover Hoodie",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1063364659.4889/ssrco,mhoodie,mens,101010:01c5ca27c6,front,square_three_quarter,x1000-bg,f8f8f8.1u2.jpg",
					Price = 30
				},
				new Product
				{
					Id = new Guid("54B2F952-B63E-4CAD-8B38-C09955FE4C62"),
					Name = "Fitted Scoop T-Shirt",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1063364659.4889/ssrco,mhoodiez,mens,101010:01c5ca27c6,front,square_three_quarter,1000x1000-bg,f8f8f8.u2.jpg",
					Price = 40
				},
				new Product
				{
					Id = new Guid("83E0AA87-158F-4E5F-A8F7-E5A98D13E3A5"),
					Name = "Zipped Hoodie",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1063364659.4889/ra,fitted_scoop,x2000,101010:01c5ca27c6,front-c,160,143,1000,1000-bg,f8f8f8.u2.jpg",
					Price = 55
				},
				//Phone
				new Product
				{
					Id = new Guid("488AAA0E-AA7E-4820-B4E9-5715F0E5186E"),
					Name = "iPhone Case & Cover",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1062161956.4889/icr,iphone_11_soft,back,a,x1000-pad,1000x1000,f8f8f8.u2.jpg",
					Price = 25
				},
				new Product
				{
					Id = new Guid("4E693871-788D-4DB4-89E5-DD7678DB975E"),
					Name = "Case & Skin for Samsung Galaxy",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1062161956.4889/icr,samsung_galaxy_s10_snap,back,a,x1000-pad,1000x1000,f8f8f8.1u2.jpg",
					Price = 35
				},
				new Product
				{
					Id = new Guid("2D3C2ABE-85EC-4D1E-9FEF-9B4BFEA5F459"),
					Name = "iPad Case & Skin",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1063329780.4889/mwo,x1000,ipad_2_snap-pad,1000x1000,f8f8f8.u2.jpg",
					Price = 45
				},
				//Home
				new Product
				{
					Id = new Guid("D1F22836-6342-480A-BE2F-035EEB010FD0"),
					Name = "Wall Clock",
					Supplier = "Code Maze",
					ImageUrl = "https://ih1.redbubble.net/image.1062161997.4889/clkc,bamboo,white,1000x1000-bg,f8f8f8.u2.jpg",
					Price = 25
				}
			);
		}
    }
}
