create table users(
	id int identity(1,1) primary key not null,
	firstname nvarchar(100) not null,
	lastname nvarchar(100) not null,
	username nvarchar(100) not null,
	email nvarchar(100) not null,
	"role" nvarchar(100) not null,
	country nvarchar(100),
	city nvarchar(100),
	postal_code nvarchar(100),
	street nvarchar(100),
	created_at datetime2(7) not null,
	updated_at datetime2(7) not null,
	is_enabled bit not null
);

create table categories(
	id int identity(1,1) primary key not null,
	"name" nvarchar(100) not null,
	created_at datetime2(7) not null,
	updated_at datetime2(7) not null,
	is_enabled bit not null
);

create table posts(
    id int identity(1,1) primary key,
    title nvarchar(100) not null,
    image_url nvarchar(100) not null,
	category_id int,
	foreign key (category_id) references categories(id) on delete set null,
	"user_id" int,
	foreign key ("user_id") references users(id) on delete set null,
    created_at datetime2(7) not null,
    updated_at datetime2(7) not null,
    is_enabled bit not null
);
