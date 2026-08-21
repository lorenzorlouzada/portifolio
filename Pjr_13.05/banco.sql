USE SistemaPedidosLouzada
GO

-- CATEGORIAS
CREATE TABLE Categorias (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100) NOT NULL
)
GO

-- CLIENTES/USUARIOS
CREATE TABLE Clientes (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100) NOT NULL,
    telefone VARCHAR(15) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    cep VARCHAR(9) NOT NULL,
    rua VARCHAR(150) NOT NULL,
    bairro VARCHAR(100) NOT NULL,
    cidade VARCHAR(100) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    perfil VARCHAR(20) NOT NULL DEFAULT 'cliente',
    CONSTRAINT CHK_perfil CHECK (perfil IN ('cliente', 'atendente', 'laboratorio')),
    CONSTRAINT CHK_email CHECK (email LIKE '%_@_%._%'),
    CONSTRAINT CHK_telefone CHECK (LEN(telefone) >= 10)
)
GO

-- PRODUTOS
CREATE TABLE Produtos (
    id INT PRIMARY KEY IDENTITY(1,1),
    nome VARCHAR(100) NOT NULL,
    descricao VARCHAR(255),
    preco DECIMAL(10,2) NOT NULL,
    temFoto BIT NOT NULL DEFAULT 0,
    ativo BIT NOT NULL DEFAULT 1,
    id_categoria INT NOT NULL,
    CONSTRAINT FK_Produtos_Categorias FOREIGN KEY (id_categoria) REFERENCES Categorias(id)
)
GO

-- TAMANHOS DE FOTO
CREATE TABLE TamanhosFoto (
    id INT PRIMARY KEY IDENTITY(1,1),
    descricao VARCHAR(50) NOT NULL,
    preco DECIMAL(10,2) NOT NULL
)
GO

-- PEDIDOS
CREATE TABLE Pedidos (
    id INT PRIMARY KEY IDENTITY(1,1),
    codigoPedido VARCHAR(20) NOT NULL UNIQUE,
    dataPedido DATETIME NOT NULL DEFAULT GETDATE(),
    status VARCHAR(20) NOT NULL DEFAULT 'Aguardando',
    observacao VARCHAR(255),
    id_cliente INT NOT NULL,
    CONSTRAINT FK_Pedidos_Clientes FOREIGN KEY (id_cliente) REFERENCES Clientes(id),
    CONSTRAINT CHK_status CHECK (status IN ('Aguardando', 'Em producao', 'Pronto', 'Retirado'))
)
GO

-- ITENS DO PEDIDO
CREATE TABLE ItensPedido (
    id INT PRIMARY KEY IDENTITY(1,1),
    quantidade INT NOT NULL DEFAULT 1,
    observacao VARCHAR(255),
    id_pedido INT NOT NULL,
    id_produto INT NOT NULL,
    id_tamanho INT NULL,
    CONSTRAINT FK_Itens_Pedido FOREIGN KEY (id_pedido) REFERENCES Pedidos(id),
    CONSTRAINT FK_Itens_Produto FOREIGN KEY (id_produto) REFERENCES Produtos(id),
    CONSTRAINT FK_Itens_Tamanho FOREIGN KEY (id_tamanho) REFERENCES TamanhosFoto(id),
    CONSTRAINT CHK_quantidade CHECK (quantidade > 0)
)
GO

-- INSERINDO CATEGORIAS INICIAIS
INSERT INTO Categorias (nome) VALUES ('Foto-Presente')
INSERT INTO Categorias (nome) VALUES ('Ótica')
INSERT INTO Categorias (nome) VALUES ('Foto-Documento')
INSERT INTO Categorias (nome) VALUES ('Revelação de Fotos')
GO

-- INSERINDO TAMANHOS DE FOTO
INSERT INTO TamanhosFoto (descricao, preco) VALUES ('10x15', 1.00)
INSERT INTO TamanhosFoto (descricao, preco) VALUES ('13x18', 2.50)
INSERT INTO TamanhosFoto (descricao, preco) VALUES ('15x21', 3.50)
INSERT INTO TamanhosFoto (descricao, preco) VALUES ('20x25', 5.00)
INSERT INTO TamanhosFoto (descricao, preco) VALUES ('A4', 8.00)
GO

-- INSERINDO USUARIO ADMIN DE DEMONSTRACAO (senha: demo123 em MD5)
INSERT INTO Clientes (nome, telefone, email, senha, cep, rua, bairro, cidade, estado, perfil)
VALUES ('Administrador Demo', '11999999999', 'admin@exemplo.com', 
'62cc2d8b4bf2d8728120d052163a77df', 
'11000-000', 'Rua Principal', 'Centro', 'Santos', 'SP', 'atendente')
GO