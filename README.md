1) Cài đặt  james Server  
2) Cấu hình domain trỏ về VPS  
3) API quản trị domain, user  
    <br> a) Domain list curl --location 'http://123.30.48.111:8000/domains' <br>
    b) Add domain  curl --location --request PUT 'http://123.30.48.111:8000/domains/gunmail.xyz' <br>
    c) Thêm 1 Email mới  <br>
     curl --location --request PUT 'http://123.30.48.111:8000/users/hanv@gunmail.xyz \ <br>
    --header 'Content-Type: application/json' \ <br>
    --data '{"password":"12345678"}' <br>
    

4) Code đọc mail 
 using (var client = new Pop3Client())  <br>
 {  <br>
     try  <br>
     {    <br>
         client.Connect("gunmail.xyz", 110, MailKit.Security.SecureSocketOptions.None); <br>
         client.Authenticate("hanv@gunmail.xyz", "12345678"); <br>
         int messageCount = client.Count; <br>
         Console.WriteLine($"Total messages: {messageCount}"); <br>
         for (int i = 0; i < messageCount; i++) <br>
         {
             MimeMessage message = client.GetMessage(i); <br>

             Console.WriteLine($"Subject: {message.Subject}"); <br>
             Console.WriteLine($"From: {message.From}"); <br>
             Console.WriteLine($"Date: {message.Date}"); <br>
             Console.WriteLine("--------------------------------------------"); <br>
         } <br>
     } <br>
     catch (Exception ex) <br>
     { <br>
         Console.WriteLine($"An error occurred: {ex.Message}"); <br>
     } <br>    
 }
