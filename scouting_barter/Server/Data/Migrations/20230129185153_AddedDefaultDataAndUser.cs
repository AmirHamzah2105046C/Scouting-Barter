using Microsoft.EntityFrameworkCore.Migrations;

namespace scouting_barter.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "a430169c-2672-4ef0-8b89-d03276424d8a", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "53a6de98-60aa-4f3a-9d0e-a88d3a2de0d1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "b1be7c7a-a8c8-4233-96b9-cfda344a4fae", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAEDgxLCh77LW1Seplbzakgdja9LZQozb28CL0PtLYflMvYZbFuQ21uA48KaxRJvsHjw==", null, false, "64c17973-74dd-41f8-ba1f-35af54954ea5", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustAddress", "CustContact", "CustDOB", "CustName" },
                values: new object[,]
                {
                    { 1, "Tampines Street 1", 91890078, "05/09/2001", "Jonathan Lim" },
                    { 2, "Serangoon Street 1", 85788009, "10/06/1985", "Haziq Hakim" },
                    { 3, "Toa Payoh Street 1", 95437721, "28/03/1999", "Gerald" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "ProductCatDesc", "ProductCatType" },
                values: new object[,]
                {
                    { 1, "Electronic devices that can be used for creating, storing, or transmitting information in the form of electronic data.", "Technological Devices" },
                    { 2, "Household decorations", "Furniture" },
                    { 3, "Equipment that are used for exercises or sports", "Sports and Fitness" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CustomerId", "ProductCategoryId", "ProductDesc", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, "MX150, Intel i3 1500, 8gb ram, 1tb hdd", "Acer Laptop 1234", 1100 },
                    { 2, 2, 2, "1989 ld cow leather couch from syria", "Old Leather Couch", 500 },
                    { 3, 3, 3, "Sports fitness mat for yoga or other forms of aerobics", "Fitness mat", 35 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
