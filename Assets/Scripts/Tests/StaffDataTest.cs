using System.Collections;
using Models;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests {
	public class StaffDataTest {
		private StaffData _data;

		[SetUp]
		public void Init() {
			_data = new StaffData("collection.json");
			_data.LoadAllData();
		}
		
		[Test]
		public void ReturnsStaffId() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(1, _data.Members[0].id);
		}
		
		[Test]
		public void ReturnsStaffListCount() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(66, _data.Members.Count);
		}
		
		[Test]
		public void ReturnsStaff() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(typeof(Staff), _data.Members[0].GetType());
		}
		
		[Test]
		public void ReturnsStaffName() {
			// Use the Assert class to test conditions.
			Assert.AreEqual("Natasha Alechina", _data.Members[0].name);
		}
		
		[Test]
		public void ReturnsStaffRoom() {
			// Use the Assert class to test conditions.
			Assert.AreEqual("C57 Computer Science", _data.Members[0].room);
		}
		
		[Test]
		public void ReturnsStaffEmail() {
			// Use the Assert class to test conditions.
			Assert.AreEqual("natasha.alechina@nottingham.ac.uk", _data.Members[0].email);
		}
		
		[Test]
		public void ReturnsStaffPhone() {
			// Use the Assert class to test conditions.
			Assert.AreEqual("01159514233", _data.Members[0].phone);
		}
		
		[Test]
		public void ReturnsStaffPosition() {
			// Use the Assert class to test conditions.
			Assert.AreEqual("Associate Professor", _data.Members[0].position);
		}
		
		[Test]
		public void ReturnsStaffType() {
			// Use the Assert class to test conditions.
			Assert.AreEqual("Academic", _data.Members[0]._type);
		}
		
		[Test]
		public void ReturnsStaffOverrideName() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(null, _data.Members[0].ovr_name);
		}
		
		[Test]
		public void ReturnsStaffOverrideRoom() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(null, _data.Members[0].ovr_room);
		}
		
		[Test]
		public void ReturnsStaffOverrideEmail() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(null, _data.Members[0].ovr_email);
		}
		
		[Test]
		public void ReturnsStaffOverridePhone() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(null, _data.Members[0].ovr_phone);
		}
		
		[Test]
		public void ReturnsStaffOverridePosition() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(null, _data.Members[0].ovr_position);
		}
		
		[Test]
		public void ReturnsStaffOverrideType() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(null, _data.Members[0].ovr_type);
		}
		
		[Test]
		public void ReturnsStaffIndex() {
			// Use the Assert class to test conditions.
			Assert.AreEqual(0, _data.Members[0]._index);
		}

		[Test]
		public void ReturnsStaffModelUrl() {
			Assert.AreEqual("/uploads/face/model_file/13/natashaalechina.obj", _data.Members[0].model_file["url"]);
		}
		[Test]
		public void ReturnsStaffUpdatedAt() {
			Assert.AreEqual(typeof(string), _data.Members[0].updated_at.GetType());
		}
		
	}
}
