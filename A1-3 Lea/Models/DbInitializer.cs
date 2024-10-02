using System.ComponentModel.Design;

namespace A22nd.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            MallStoreDbContext context =
                applicationBuilder.ApplicationServices.CreateScope().
                ServiceProvider.GetRequiredService<MallStoreDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Stores.Any())
            {
                context.AddRange
                (
                    new Store { Name = "Chanel", ImageUrl = "Images/CHANEL.png", ImageThumbnailUrl = "Images/CHANEL.png", LongDescription = "We offer skin, hair and body care formulations created with meticulous attention to detail, and with efficacy and sensory pleasure in mind. Our objective has always been to formulate skin, hair and body care products of the finest quality; we investigate widely to source plant-based and laboratory-made ingredients, and use only those with a proven record of safety and efficacy.", Category = Categories["Cosmetics"] },
                    new Store { Name = "Tom Ford", ImageUrl = "Images/TOMFORD.jpg", ImageThumbnailUrl = "Images/TOMFORD.jpg", LongDescription = "Burberry Group plc is a British luxury fashion house established in 1856 by Thomas Burberry and headquartered in London, England. It designs and distributes ready to wear, including trench coats, leather accessories, and footwear.", Category = Categories["Designer Luxury"] },
                    new Store { Name = "Macdonalds", ImageUrl = "Images/MACDONALD.jpg", ImageThumbnailUrl = "Images/MACDONALD.jpg", LongDescription = "McDonald's Corporation is an American multinational fast food chain, founded in 1940 as a restaurant operated by Richard and Maurice McDonald, in San Bernardino, California, United States. They rechristened their business as a hamburger stand, and later turned the company into a franchise.", Category = Categories["Food Court"] },
                    new Store { Name = "LV", ImageUrl = "Images/LV.png", ImageThumbnailUrl = "Images/LV.png", LongDescription = "Louis Vuitton Malletier, commonly known as Louis Vuitton, is a French luxury fashion house and company founded in 1854 by Louis Vuitton. The label's LV monogram appears on most of its products, ranging from luxury bags and leather goods to ready-to-wear, shoes, perfumes, watches, jewellery, accessories, sunglasses and books. Louis Vuitton is one of the world's leading international fashion houses. It sells its products through standalone boutiques, lease departments in high-end departmental stores, and through the e-commerce section of its website.", Category = Categories["Designer Luxury"] },
                    new Store { Name = "Aēsop", ImageUrl = "Images/AESOP.png", ImageThumbnailUrl = "Images/AESOP.png", LongDescription = "Aēsop is an Australian luxury cosmetics brand that offer skin, hair, body care and fragrance products formulations created with meticulous attention to detail, and with efficacy and sensory pleasure in mind. It is headquartered in Collingwood, Victoria and is a subsidiary of L’Oréal.", Category = Categories["Beauty"] },
                    new Store { Name = "The Body Shop", ImageUrl = "Images/The Body Shop.jpg", ImageThumbnailUrl = "Images/The Body Shop.jpg", LongDescription = "The Body Shop International plc is a global manufacturer and retailer of naturally inspired, ethically produced beauty and cosmetics products.", Category = Categories["Beauty"] },
                    new Store { Name = "4 Seasons Nails", ImageUrl = "Images/4 Seasons Nails.png", ImageThumbnailUrl = "Images/4 Seasons Nails.png", LongDescription = "4 Seasons Nails is Wellington's top nail & beauty therapy salon. We provide full of nail care services including manicure, pedicure, acrylic and hard gel nails extensions, nail art and gel polish, SNS nails.", Category = Categories["Beauty"] },
                    new Store { Name = "ASB Bank", ImageUrl = "Images/ASB Bank.png", ImageThumbnailUrl = "Images/ASB Bank.png", LongDescription = "ASB Bank Limited, commonly stylised as ASB, is a bank owned by Commonwealth Bank of Australia, operating in New Zealand. It provides a range of financial services including retail, business and rural banking, funds management, as well as insurance through its Sovereign Limited subsidiary, and investment and securities services through its ASB Group Investments and ASB Securities divisions. ASB also operated BankDirect, a branchless banking service that provided service via phone, Internet, EFTPOS and ATMs only.", Category = Categories["Banks"] },
                    new Store { Name = "ANZ Bank", ImageUrl = "Images/ANZ Bank.png", ImageThumbnailUrl = "Images/ANZ Bank.png", LongDescription = "The Australia and New Zealand Banking Group Limited (ANZ) is a multinational banking and financial services company headquartered in Melbourne, Victoria, Australia. It is Australia's second-largest bank by assets and fourth-largest bank by market capitalisation.", Category = Categories["Banks"] },
                    new Store { Name = "Kiwibank", ImageUrl = "Images/Kiwibank.png", ImageThumbnailUrl = "Images/Kiwibank.png", LongDescription = "Kiwibank Limited is a New Zealand state-owned bank and financial services provider. As of 2023, Kiwibank is the fifth-largest bank in New Zealand by assets, and the largest New Zealand-owned bank, with a market share of approximately 9%.", Category = Categories["Banks"] },
                    new Store { Name = "Bed Bath N' Table", ImageUrl = "Images/Bed Bath N' Table.png", ImageThumbnailUrl = "Images/Bed Bath N' Table.png", LongDescription = "Bed Bath N' Table has been proud to bring beautiful product and decorating ideas into the homes of our customers for over 60 years. From our design studio and head office in Melbourne, it is our continuous goal to make your life at home a pleasure.", Category = Categories["Homeware"] },
                    new Store { Name = "Bed Bath & Beyond", ImageUrl = "Images/Bed Bath & Beyond.png", ImageThumbnailUrl = "Images/Bed Bath & Beyond.png", LongDescription = "Bed Bath & Beyond is New Zealand's largest manchester specialist. We strive daily to offer you the biggest range at the most competitive prices. Bed Bath and Beyond began in 1995 under the name 'Linen for Less' selling seconds and overuns from a bedding manufacturer in Auckland.", Category = Categories["Homeware"] },
                    new Store { Name = "Sephora", ImageUrl = "Images/Sephora.png", ImageThumbnailUrl = "Images/Sephora.png", LongDescription = "Sephora is a French multinational retailer of personal care and beauty products with nearly 340 brands, along with its own private label, Sephora Collection, and includes beauty products such as cosmetics, skincare, fragrance, nail color, beauty tools, body lotions, and haircare.", Category = Categories["Cosmetics"] },
                    new Store { Name = "MECCA", ImageUrl = "Images/MECCA.png", ImageThumbnailUrl = "Images/MECCA.png", LongDescription = "Mecca Brands Pty Ltd is engaged in the retail sale of cosmetics, skincare and related products both in-store and online. The company operates stores under three different monikers which reflects the store type, with stores either self-standing or operating within Myer department stores.", Category = Categories["Cosmetics"] },
                    new Store { Name = "VERSACE", ImageUrl = "Images/VERSACE.png", ImageThumbnailUrl = "Images/VERSACE.png", LongDescription = "The Versace lifestyle includes women's, men's, and children's ready-to-wear, shoes, bags and accessories, Atelier Versace haute couture, eyewear, fragrances, watches, Palazzo Versace hotels, Versace Home homeware, and the Versace Jeans Couture youth line.", Category = Categories["Designer Luxury"] },
                    new Store { Name = "BURBERRY", ImageUrl = "Images/BURBERRY.png", ImageThumbnailUrl = "Images/BURBERRY.png", LongDescription = "Burberry Group plc is a British luxury fashion house established in 1856 by Thomas Burberry and headquartered in London, England. It designs and distributes ready to wear, including trench coats, leather accessories, and footwear.", Category = Categories["Designer Luxury"] },
                    new Store { Name = "GONCHA", ImageUrl = "Images/GONCHA.png", ImageThumbnailUrl = "Images/GONCHA.png", LongDescription = "Gong cha is an international beverage franchise specializing in freshly prepared premium tea, bubble tea and coffee. With a successful business model and proven track record, it has opened over 2000 stores in 23 countries.", Category = Categories["Food Court"] }
                );
            }

            /*	if (!context.Stores.Any())
                {
                    context.Stores.AddRange(Stores.Select(c => c.Value));
                }*/

            if (!context.GiftCards.Any())
            {
                // Get the first store in the database (you can change this logic as needed)
                var firstStore = context.Stores.FirstOrDefault();

                // Add gift cards associated with the first store
                context.AddRange
                (
                    new GiftCard { GiftCardPrice = 10, GiftCardDescription = "", Store = firstStore },
                    new GiftCard { GiftCardPrice = 15, GiftCardDescription = "", Store = firstStore }
                );
            }



            context.SaveChanges();
        }



        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Cosmetics" },
                        new Category { CategoryName = "Designer Luxury" },
                        new Category { CategoryName = "Food Court" },
                        new Category { CategoryName = "Beauty" },
                        new Category { CategoryName = "Banks" },
                        new Category { CategoryName = "Homeware" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }

        }
    }
}
