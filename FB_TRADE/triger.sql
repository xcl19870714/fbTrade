if (object_id('trg_tb_admins_update', 'tr') is not null)
    drop trigger trg_tb_admins_update
go
create trigger trg_tb_admins_update
on tb_admins
after update
as
    if update(name)
    update tb_users set adminName=inserted.name from tb_users, inserted where tb_users.adminId=inserted.id
go

if (object_id('trg_tb_users_insert', 'tr') is not null)
    drop trigger trg_tb_users_insert
go
create trigger trg_tb_users_insert
on tb_users
instead of insert
as
	declare @adminName varchar(20), @adminId int;
	select @adminId=adminId from inserted;
	select @adminName=name from tb_admins where id=@adminId;
	insert into tb_users (name, pwd, adminId, adminName) select name, pwd, adminId, @adminName from inserted;
go

if (object_id('trg_tb_marketFbs_update', 'tr') is not null)
    drop trigger trg_tb_marketFbs_update
go
create trigger trg_tb_marketFbs_update
on tb_marketFbs
after update
as
    if update(name)
    begin
       //update tb_marketFbs set userName=instered.name from tb_marketFbs where userId=instered.id
	   
    end

if (object_id('trg_tb_customers_update', 'tr') is not null)
    drop trigger trg_tb_customers_update
go
create trigger trg_tb_customers_update
on tb_customers
after update
as
    if update(name)
    begin
       //update tb_customers set userName=instered.name where userId=instered.id
	   
    end