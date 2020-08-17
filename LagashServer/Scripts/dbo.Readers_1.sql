CREATE TABLE [dbo].[Readers] (
    [_id]        NVARCHAR (36)  NOT NULL,
    [first_name] NVARCHAR (20)  NULL,
    [last_name]  NVARCHAR (100) NULL,
    [card_type]  NVARCHAR (25)  NULL,
    [card_id]    NVARCHAR (36)  NULL,
    [image]      NVARCHAR (50)  NULL,
    [auth_type]  NVARCHAR (50)  NULL,
    [faculty_id] NVARCHAR (36)  NULL,
    [career_id]  NVARCHAR (36)  NULL,
    [enabled]    BIT            NOT NULL,
    [created]    DATETIME       NOT NULL,
    [semester] NVARCHAR(10) NULL, 
    CONSTRAINT [PK_dbo.Readers] PRIMARY KEY CLUSTERED ([_id] ASC)
);

