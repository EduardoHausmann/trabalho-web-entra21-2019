DROP TABLE IF EXISTS tarefas, categorias, usuarios, projetos, clientes, cidades, estados;
CREATE TABLE estados(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	sigla VARCHAR(2)
);

CREATE TABLE cidades(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_estado INT,
	FOREIGN KEY(id_estado) REFERENCES estados(id)
	ON DELETE CASCADE ON UPDATE CASCADE,

	nome VARCHAR(20),
	numero_habitantes INT
);

CREATE TABLE clientes(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_cidade INT,
	FOREIGN KEY(id_cidade) REFERENCES cidades(id)
	ON DELETE CASCADE ON UPDATE CASCADE,

	nome VARCHAR(50),
	cpf VARCHAR(50),
	numero INT,
	complemento VARCHAR(75),
	logradouro VARCHAR(75),
	cep VARCHAR(25)
);

CREATE TABLE projetos(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_cliente INT,
	FOREIGN KEY(id_cliente) REFERENCES clientes(id)
	ON DELETE CASCADE ON UPDATE CASCADE,

	nome VARCHAR(50),
	data_criacao DATETIME
);

CREATE TABLE usuarios(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50),
	login VARCHAR(50),
	senha VARCHAR(50)
);

CREATE TABLE categorias(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50)
);

CREATE TABLE tarefas(
	id INT PRIMARY KEY IDENTITY(1,1),

	id_usuario INT,
	FOREIGN KEY(id_usuario) REFERENCES usuarios(id)
	ON DELETE CASCADE ON UPDATE CASCADE,

	id_projeto INT,
	FOREIGN KEY(id_projeto) REFERENCES projetos(id)
	ON DELETE CASCADE ON UPDATE CASCADE,

	id_categoria INT,
	FOREIGN KEY(id_categoria) REFERENCES categorias(id)
	ON DELETE CASCADE ON UPDATE CASCADE,

	titulo VARCHAR(50),
	descricao TEXT
);