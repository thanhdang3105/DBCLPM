using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLNS_TinhVanSoftWare.BusinessLogicLayer;
using System;

namespace UnitTestLogin
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_DangNhap_Successfully()
        {
            DangNhapBLL dangNhapBLL = new DangNhapBLL();
            String tenTK = "manh";
            String matKhau = "cccccc";
            int expected = 1;
            int actual = dangNhapBLL.login(tenTK, matKhau);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_DangNhap_TenTK_Does_Not_Exist()
        {
            DangNhapBLL dangNhapBLL = new DangNhapBLL();
            String tenTK = "Linh Thai";
            String matKhau = "cccccc";
            int expected = 0;
            int actual = dangNhapBLL.login(tenTK, matKhau);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_DangNhap_MK_Does_Not_Exist()
        {
            DangNhapBLL dangNhapBLL = new DangNhapBLL();
            String tenTK = "manh";
            String matKhau = "1234567";
            int expected = 2;
            int actual = dangNhapBLL.login(tenTK, matKhau);
            Assert.AreEqual(expected, actual);
        }

    }
}
