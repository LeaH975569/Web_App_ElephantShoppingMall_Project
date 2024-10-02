namespace A22nd.Models
{
    public class MockStoreRepository : IStoreRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        private List<Store> _stores;

        public MockStoreRepository()
        {
            _stores = new List<Store>
            {
                new Store {StoreId = 1, Name="Chanel", ImageUrl="Images/CHANEL.png", ImageThumbnailUrl="Images/CHANEL.png", LongDescription="We offer skin, hair and body care formulations...", Category = _categoryRepository.AllCategories.ToList()[0] },
                new Store {StoreId = 2, Name="Tom Ford", ImageUrl="Images/TOMFORD.jpg", ImageThumbnailUrl="Images/TOMFORD.jpg", LongDescription="Burberry Group plc is a British luxury fashion house established in 1856 by Thomas Burberry and headquartered in London, England. It designs and distributes ready to wear, including trench coats, leather accessories, and footwear.", Category = _categoryRepository.AllCategories.ToList()[1]},
                new Store {StoreId = 3, Name="Macdonalds", ImageUrl="Images/MACDONALD.jpg", ImageThumbnailUrl="Images/MACDONALD.jpg", LongDescription="McDonald's Corporation is an American multinational fast food chain, founded in 1940 as a restaurant operated by Richard and Maurice McDonald, in San Bernardino, California, United States. They rechristened their business as a hamburger stand, and later turned the company into a franchise.", Category = _categoryRepository.AllCategories.ToList()[2]},
                new Store {StoreId = 4, Name="LV", ImageUrl="Images/LV.png", ImageThumbnailUrl="Images/LV.png", LongDescription="Louis Vuitton Malletier, commonly known as Louis Vuitton, is a French luxury fashion house and company founded in 1854 by Louis Vuitton. The label's LV monogram appears on most of its products, ranging from luxury bags and leather goods to ready-to-wear, shoes, perfumes, watches, jewellery, accessories, sunglasses and books. Louis Vuitton is one of the world's leading international fashion houses. It sells its products through standalone boutiques, lease departments in high-end departmental stores, and through the e-commerce section of its website.", Category = _categoryRepository.AllCategories.ToList()[1]},
                new Store {StoreId = 5, Name="Aēsop", ImageUrl="Images/AESOP.png", ImageThumbnailUrl="Images/AESOP.png", LongDescription="Aēsop is an Australian luxury cosmetics brand that offer skin, hair, body care and fragrance products formulations created with meticulous attention to detail, and with efficacy and sensory pleasure in mind. It is headquartered in Collingwood, Victoria and is a subsidiary of L’Oréal.", Category = _categoryRepository.AllCategories.ToList()[3]},
                new Store {StoreId = 6, Name="The Body Shop", ImageUrl="Images/The Body Shop.jpg", ImageThumbnailUrl="Images/The Body Shop.jpg", LongDescription="The Body Shop International plc is a global manufacturer and retailer of naturally inspired, ethically produced beauty and cosmetics products.", Category = _categoryRepository.AllCategories.ToList()[3]},
                new Store {StoreId = 7, Name="4 Seasons Nails", ImageUrl="Images/4 Seasons Nails.png", ImageThumbnailUrl="Images/4 Seasons Nails.png", LongDescription="4 Seasons Nails is Wellington's top nail & beauty therapy salon. We provide full of nail care services including manicure, pedicure, acrylic and hard gel nails extensions, nail art and gel polish, SNS nails.", Category = _categoryRepository.AllCategories.ToList()[3]},
                new Store {StoreId = 8, Name="ASB Bank", ImageUrl="Images/ASB Bank.png", ImageThumbnailUrl="Images/ASB Bank.png", LongDescription="ASB Bank Limited, commonly stylised as ASB, is a bank owned by Commonwealth Bank of Australia, operating in New Zealand. It provides a range of financial services including retail, business and rural banking, funds management, as well as insurance through its Sovereign Limited subsidiary, and investment and securities services through its ASB Group Investments and ASB Securities divisions. ASB also operated BankDirect, a branchless banking service that provided service via phone, Internet, EFTPOS and ATMs only.", Category = _categoryRepository.AllCategories.ToList()[4]},
                new Store {StoreId = 9, Name="ANZ Bank", ImageUrl="Images/ANZ Bank.png", ImageThumbnailUrl="Images/ANZ Bank.png", LongDescription="The Australia and New Zealand Banking Group Limited (ANZ) is a multinational banking and financial services company headquartered in Melbourne, Victoria, Australia. It is Australia's second-largest bank by assets and fourth-largest bank by market capitalisation.", Category = _categoryRepository.AllCategories.ToList()[4]},
                new Store {StoreId = 10, Name="Kiwibank", ImageUrl="Images/Kiwibank.png", ImageThumbnailUrl="Images/Kiwibank.png", LongDescription="Kiwibank Limited is a New Zealand state-owned bank and financial services provider. As of 2023, Kiwibank is the fifth-largest bank in New Zealand by assets, and the largest New Zealand-owned bank, with a market share of approximately 9%.", Category = _categoryRepository.AllCategories.ToList()[4]},
                new Store {StoreId = 11, Name="Bed Bath N' Table", ImageUrl="Images/Bed Bath N' Table.png", ImageThumbnailUrl="Images/Bed Bath N' Table.png", LongDescription="Bed Bath N' Table has been proud to bring beautiful product and decorating ideas into the homes of our customers for over 60 years. From our design studio and head office in Melbourne, it is our continuous goal to make your life at home a pleasure.", Category = _categoryRepository.AllCategories.ToList()[5]},
                new Store {StoreId = 12, Name="Bed Bath & Beyond", ImageUrl="Images/Bed Bath & Beyond.png", ImageThumbnailUrl="Images/Bed Bath & Beyond.png", LongDescription="Bed Bath & Beyond is New Zealand's largest manchester specialist. We strive daily to offer you the biggest range at the most competitive prices. Bed Bath and Beyond began in 1995 under the name 'Linen for Less' selling seconds and overuns from a bedding manufacturer in Auckland.", Category = _categoryRepository.AllCategories.ToList()[5]},
                new Store {StoreId = 13, Name="Sephora", ImageUrl="Images/Sephora.png", ImageThumbnailUrl="Images/Sephora.png", LongDescription="Sephora is a French multinational retailer of personal care and beauty products with nearly 340 brands, along with its own private label, Sephora Collection, and includes beauty products such as cosmetics, skincare, fragrance, nail color, beauty tools, body lotions, and haircare.", Category = _categoryRepository.AllCategories.ToList()[0]},
                new Store {StoreId = 14, Name="MECCA", ImageUrl="Images/MECCA.png", ImageThumbnailUrl="Images/MECCA.png", LongDescription="Mecca Brands Pty Ltd is engaged in the retail sale of cosmetics, skincare and related products both in-store and online. The company operates stores under three different monikers which reflects the store type, with stores either self-standing or operating within Myer department stores.", Category = _categoryRepository.AllCategories.ToList()[0]},
                new Store {StoreId = 15, Name="VERSACE", ImageUrl="Images/VERSACE.png", ImageThumbnailUrl="Images/VERSACE.png", LongDescription="The Versace lifestyle includes women's, men's, and children's ready-to-wear, shoes, bags and accessories, Atelier Versace haute couture, eyewear, fragrances, watches, Palazzo Versace hotels, Versace Home homeware, and the Versace Jeans Couture youth line.", Category = _categoryRepository.AllCategories.ToList()[1]},
                new Store {StoreId = 16, Name="BURBERRY", ImageUrl="Images/BURBERRY.png", ImageThumbnailUrl="Images/BURBERRY.png", LongDescription="Burberry Group plc is a British luxury fashion house established in 1856 by Thomas Burberry and headquartered in London, England. It designs and distributes ready to wear, including trench coats, leather accessories, and footwear.", Category = _categoryRepository.AllCategories.ToList()[1]},
                new Store {StoreId = 17, Name="GONCHA", ImageUrl="Images/GONCHA.png", ImageThumbnailUrl="Images/GONCHA.png", LongDescription="Gong cha is an international beverage franchise specializing in freshly prepared premium tea, bubble tea and coffee. With a successful business model and proven track record, it has opened over 2000 stores in 23 countries.", Category = _categoryRepository.AllCategories.ToList()[2]}
    };
        }

        public IEnumerable<Store> AllStores => _stores;

        public Store? GetStoreById(int storeId) => _stores.FirstOrDefault(p => p.StoreId == storeId);

        public IEnumerable<Store> SearchStores(string searchQuery)
        {
            return _stores.Where(s => s.Name.Contains(searchQuery));
        }

        public void Create(Store store)
        {
            store.StoreId = _stores.Max(s => s.StoreId) + 1;
            _stores.Add(store);
        }

        public void Update(Store store)
        {
            var existingStore = _stores.FirstOrDefault(s => s.StoreId == store.StoreId);
            if (existingStore != null)
            {
                existingStore.Name = store.Name;
                existingStore.LongDescription = store.LongDescription;
                existingStore.ImageUrl = store.ImageUrl;
                existingStore.ImageThumbnailUrl = store.ImageThumbnailUrl;
                existingStore.CategoryId = store.CategoryId;
            }
        }

        public void Delete(int storeId)
        {
            var storeToDelete = _stores.FirstOrDefault(s => s.StoreId == storeId);
            if (storeToDelete != null)
            {
                _stores.Remove(storeToDelete);
            }
        }
    }
}