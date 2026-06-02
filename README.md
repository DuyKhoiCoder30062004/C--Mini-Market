
## ERD (Xài SQL Server khi DEMO chính yếu cho thầy, nghĩa là team lead DEMO, gộp code hết tất tật rồi connect với SQL Server)
## Bỏ cột department_id 
## Thêm cột password, username vào table Customers
## Thêm Table Orders (quên)
<img width="1291" height="929" alt="image" src="https://github.com/user-attachments/assets/e1558d9c-867c-4a89-a3d7-b88d6e5443fb" />
##File sql ở trong cấu trúc cây repo (sql server)



## SQL demo screenshot
![SQL](./SQL.png)

I use docker to build everything. Because I don't want to break anything. So there is how I create this database:

```bash
# We will do everything in this container
[host]$ docker run -it ubuntu /bin/bash
# Then inside the container
[container]$ sqlite3 database.sqlite3 < script.sql # sqlite must be installed


```
# C# Mini Market Figma Design for UI.
