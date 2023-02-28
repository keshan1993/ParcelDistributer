



CREATE PROCEDURE [dbo].[spFindAvailableDriver]
(
	@dtDeliveryDate			DATETIME
)
AS
BEGIN

	SELECT numDriverID,varDriverName,varDriverAddress,varDriverNIC,varDriverContactNo,bitActive,dtCreatedDate,dteditedDate,dtDeletedDate
	FROM dbo.Driver
	WHERE numDriverID NOT IN (SELECT numDriverID FROM dbo.Booking WHERE dtDeliveryDate = @dtDeliveryDate AND bitActive = 1)

END
