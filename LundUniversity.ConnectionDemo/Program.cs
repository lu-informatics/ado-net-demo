using LundUniversity.ConnectionDemo;

DataAccessLayer accessLayer = new();

accessLayer.InsertEmployee("E7", "Leo", 95000, "Computer Science");

accessLayer.PrintAllEmployees();