namespace WebUI.APIHandler
{
    public static class UrlStrings
    {
        //Api AuthController Endpoints
        public static string LoginUser = "Auth/Login";
        public static string RegisterMember = "Auth/RegisterMember";
        public static string GetByCompany = "Auth/GetByCompany";
        //Api BrandController Endpoints
        public static string GetAllBrand = "Brand/GetAllBrand";
        public static string AddNewBrand = "Brand/AddNewBrand";
        public static string UpdateBrand = "Brand/UpdateBrand";
        //Api CategoryController Endpoints
        public static string GetAllCategory = "Category/GetAllCategory";
        public static string AddCategory = "Category/AddCategory";
        public static string UpdateCategory = "Category/UpdateCategory";
        //Api ProductController Endpoints
        public static string AddProduct = "Product/AddProduct";
        public static string GetAllProduct = "Product/GetAllProduct";
        public static string GetAllCompanyProducts = "Product/GetAllCompanyProducts/";
        public static string GetProductFeatures = "Product/GetProductFeatures/";
        public static string AddProductFeature = "Product/AddProductFeature";

    }
}
