if (object_id('trg_tb_fbOrders_insert', 'tr') is not null)
    drop trigger trg_tb_fbOrders_insert
go
create trigger trg_tb_fbOrders_insert
on tb_fbOrders
instead of insert
as
	declare @marketFbId varchar(30), @userId int;
	select @marketFbId=marketFbId from inserted;
	select @userId=userId from tb_fbMarketAccounts where fbId=@marketFbId;
	
	declare @userIdStr varchar(20);
	set @userIdStr = right('0000'+ cast(@userId as varchar(4)), 4)

	/* get cur date string: 20190318 */
	declare @timeNow datetime;
	declare @dateToday nvarchar(11)
	set @timeNow = getdate();
	set @dateToday = left(Convert(Varchar(4),Year(@timeNow)),2) + CONVERT(VARCHAR(8),@timeNow,12)
	
	/* get max order id in database */
	declare @maxOrderId varchar(30), @nextOrderId varchar(30)
	select @maxOrderId=max(orderId) from tb_fbOrders where marketFbid=@marketFbId
	
	if @maxOrderId is null
	begin
		set  @nextOrderId = @userIdStr + @dateToday + '001'
	end
	else
	begin
		declare @dateCom nvarchar(8)
		set @dateCom = right(left(@maxOrderId, len(@userIdStr) + 8),8)
		if @dateCom<> @dateToday
		begin
			set  @nextOrderId = @userIdStr + @dateToday + '001'
		end
		else
		begin
			declare @tempBibInt bigint
			set @tempBibInt = convert(bigint,right(@maxOrderId, 11)) + 1
			set @nextOrderId = @userIdStr + convert(Varchar(30),@tempBibInt)
		end
	end

	insert into tb_fbOrders (orderId,customerFbId,marketFbId,orderType,oriOrderId,createTime,lastEditTime,status,shippingAddress,shippingName,shippingPhone,shippingType,shippingNo,currency,totalPrice,paymentType,paymentNo,note) select @nextOrderId,customerFbId,marketFbId,orderType,oriOrderId,getdate(),getdate(),status,shippingAddress,shippingName,shippingPhone,shippingType,shippingNo,currency,totalPrice,paymentType,paymentNo,note from inserted;
go


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