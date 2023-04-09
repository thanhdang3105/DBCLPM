using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLNS_TinhVanSoftWare.BusinessLogicLayer;
using QLNS_TinhVanSoftWare.DataAccessLayer;
using System;
using System.Globalization;

namespace UnitTest_QLNS_TinhVanSoftware
{
    [TestClass]
    public class UnitTest1
    {
        //NhanVienDAL nhanVienDAL = new NhanVienDAL();


        [TestMethod]
        public void TestMethod_Update_Employee_Successfully()
        {
            NhanVienBLL nhanVienBLL = new NhanVienBLL();

            bool expected = true;
            bool actual = nhanVienBLL.update("NV00001", "Nguyen Van Manh", DateTime.Parse("01/01/2001"), "Nam", "001201325412", "Ha Noi", "0952678451", "manhnv@gmail.com", DateTime.Parse("01/01/2023"));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_Update_EmployeeCode_Does_Not_Exist()
        {
            NhanVienBLL nhanVienBLL = new NhanVienBLL();

            bool expected = false;
            bool actual = nhanVienBLL.update("NV01", "Nguyen Van Manh", DateTime.Parse("01/01/2001"), "Nam", "001201325412", "Ha Noi", "0952678451", "manhnv@gmail.com", DateTime.Parse("01/01/2023"));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_Delete_Employee_With_EmployeeCodeTrue()
        {
            NhanVienBLL nhanVienBLL = new NhanVienBLL();

            bool expected = true;
            bool actual = nhanVienBLL.deleteById("22");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_Delete_Employee_With_EmployeeCode_Does_Not_Exist()
        {
            NhanVienBLL nhanVienBLL = new NhanVienBLL();

            bool expected = false;
            bool actual = nhanVienBLL.deleteById("NV01");

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod_Search_Employee_With_EmployeeCodeTrue()
        {
            NhanVienBLL nhanVienBLL = new NhanVienBLL();

            bool expected = true;
            bool actual = nhanVienBLL.searchByIdOrName("NV00001", "Nguyen Van Manh").Rows.Count > 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_Search_Employee_With_EmployeeCode_Does_Not_Exist()
        {
            NhanVienBLL nhanVienBLL = new NhanVienBLL();

            bool expected = false;
            bool actual = nhanVienBLL.searchByIdOrName("NV01", "Pham Le Viet Tu").Rows.Count > 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_InsertEmployee_Successfully()
        {
            NhanVienBLL nhanVienBLL = new NhanVienBLL();

            bool expected = true;
            DateTime ngaySinh = DateTime.ParseExact("20/01/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime ngayThamGia = DateTime.ParseExact("06/01/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            bool actual = nhanVienBLL.insert("NV00051", "Nguyen Thi Thuy", ngaySinh, "Nữ", "013167123123", "Ha Noi", "0987651446", "nguyenthuy@gmail.com", ngayThamGia);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_InsertEmploye_DoesNotExist()
        {
            NhanVienBLL nhanVienBLL = new NhanVienBLL();

            bool expected = false;
            DateTime ngaySinh = DateTime.ParseExact("20/01/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime ngayThamGia = DateTime.ParseExact("06/01/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            bool actual = nhanVienBLL.insert("NV00051", "Nguyen Thi Thuy", ngaySinh, "Nữ", "013167123123", "Ha Noi", "0987651446", "nguyenthuy@gmail.com", ngayThamGia);

            Assert.AreEqual(expected, actual);
        }
    }
}


   
