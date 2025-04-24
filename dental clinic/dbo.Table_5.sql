CREATE TABLE [dbo].[Table] (
    [presId]  INT          NOT NULL IDENTITY(2000, 1),
    [PatName] VARCHAR (50) NOT NULL,
    [TreatName] VARCHAR(50) NOT NULL, 
    [TreatCost] VARCHAR(50) NOT NULL, 
    [Medicine] VARCHAR(100) NOT NULL, 
    [MedQty] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([presId] ASC)
);

