DROP TABLE IF EXISTS estados;
CREATE TABLE estados(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	sigla VARCHAR(2)
);

DROP TABLE IF EXISTS cidades;
CREATE TABLE cidades(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_estado INT,
	FOREIGN KEY(id_estado) REFERENCES estados(id),

	nome VARCHAR(20),
	numero_habitantes INT
);

DROP TABLE IF EXISTS clientes;
CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_cidade INT,
	FOREIGN KEY(id_cidade) REFERENCES cidades(id),

	nome VARCHAR(50),
	cpf VARCHAR(50),
	data_nascimento DATETIME2(7),
	numero INT,
	complemento NCHAR(10),
	logradouro NCHAR(10),
	cep NCHAR(10)
);

select* from clientes;

DROP TABLE IF EXISTS projetos;
CREATE TABLE projetos(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_cliente INT,
	FOREIGN KEY(id_cliente) REFERENCES clientes(id),

	nome VARCHAR(50),
	data_criacao DATETIME2(7),
	data_finalizacao DATETIME2(7)
);

DROP TABLE IF EXISTS usuarios;
CREATE TABLE usuarios(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	login VARCHAR(50),
	senha VARCHAR(50)
);

DROP TABLE IF EXISTS categorias;
CREATE TABLE categorias(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50)
);

DROP TABLE IF EXISTS tarefas;
CREATE TABLE tarefas(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_usuario_responsavel INT,
	FOREIGN KEY(id_usuario_responsavel) REFERENCES usuarios(id),

	id_projeto INT,
	FOREIGN KEY(id_projeto) REFERENCES projetos(id),

	id_categoria INT,
	FOREIGN KEY(id_categoria) REFERENCES categorias(id),

	titulo VARCHAR(50),
	descricao TEXT,
	duracao DATETIME2(7)
);