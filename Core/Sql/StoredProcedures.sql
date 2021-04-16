-- DROP and CREATE non-generated stored procedures

DROP PROC dbo.GetAllContacts
DROP PROC dbo.GetAllVendors
DROP PROC dbo.GetVendorsBySubCategoryUse
DROP PROC dbo.GetAllProductBrands
DROP PROC dbo.GetAllProductCategories
DROP PROC dbo.GetAllProductSubCategories
DROP PROC dbo.GetVendorProductsByVendor
DROP PROC dbo.GetVendorProductsByVendorCategory
DROP PROC dbo.GetVendorProductsByProduct
DROP PROC dbo.GetVendorProductsByPartNum
DROP PROC dbo.GetVendorCategoryByBrand
DROP PROC dbo.GetProductsByVendor
DROP PROC dbo.GetProductsByVendorCategory
DROP PROC dbo.GetProductsByBrandCategory
DROP PROC dbo.GetProductsByBrandNameSize
DROP PROC dbo.GetPurOrderByOrderDate
DROP PROC dbo.GetPurOrderByVendorProduct
DROP PROC dbo.GetPurLineByPurOrder
DROP PROC dbo.GetPurLineByShelfOrder
DROP PROC dbo.PurLineGetCategories
DROP PROC dbo.PurLineAddCategory
DROP PROC dbo.PurLineRemoveCategory
DROP PROC dbo.PurLineRefreshFromDefinitions
DROP PROC dbo.PurLineSaveToDefinitions

DROP VIEW dbo.PurLinesForProduct

GO
-----------------------------------------------------

CREATE VIEW dbo.PurLinesForProduct

AS

-- Filter by VendorProductIdSel to find all PurLine rows for that VendorProductId
-- or one which maps to the same ProductId.

SELECT	vpsel.VendorProductId VendorProductIdSel, po.VendorId, po.OrderDate,
		po.PurOrderId, pl.PurLineId, pl.OrderedEaches, pl.QtyOrdered,
		vppur.CountInCase, pl.VendorProductId
FROM	dbo.VendorProduct vpsel
		JOIN dbo.Product pr ON vpsel.ProductId = pr.ProductId
		JOIN dbo.VendorProduct vppur ON pr.ProductId = vppur.ProductId
		JOIN dbo.PurLine pl ON vppur.VendorProductId = pl.VendorProductId
		JOIN dbo.PurOrder po ON pl.PurOrderId = po.PurOrderId
GO

-----------------------------------------------------

CREATE PROC dbo.GetAllContacts

AS

SELECT	*
FROM	dbo.Contact
ORDER BY
		LastName, FirstName

GO

GRANT EXECUTE ON dbo.GetAllContacts TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetAllVendors

AS

SELECT	*
FROM	dbo.Vendor
ORDER BY
		SortCode, VendorName

GO

GRANT EXECUTE ON dbo.GetAllVendors TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetVendorsBySubCategoryUse
	@ProductSubCategoryId int
AS

SELECT	v.*
FROM	dbo.Vendor v
WHERE	EXISTS
		(
		SELECT	*
		FROM	VendorProduct vp
				JOIN Product pr ON vp.ProductId = pr.ProductId
		WHERE	vp.VendorId = v.VendorId
				AND pr.ProductSubCategoryId = @ProductSubCategoryId
		)
ORDER BY
		SortCode, VendorName

GO

GRANT EXECUTE ON dbo.GetVendorsBySubCategoryUse TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetAllProductBrands

AS

SELECT	*
FROM	dbo.ProductBrand
ORDER BY
		BrandName

GO

GRANT EXECUTE ON dbo.GetAllProductBrands TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetAllProductCategories

AS

SELECT	*
FROM	dbo.ProductCategory
ORDER BY
		SortCode

GO

GRANT EXECUTE ON dbo.GetAllProductCategories TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetAllProductSubCategories

AS

SELECT	sc.*
FROM	dbo.ProductSubCategory sc
		JOIN dbo.ProductCategory c ON sc.ProductCategoryId = c.ProductCategoryId
ORDER BY
		c.SortCode, sc.SortCode

GO

GRANT EXECUTE ON dbo.GetAllProductSubCategories TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetVendorProductsByVendor
	@VendorId int
AS

SELECT	vp.*
FROM	VendorProduct vp
		JOIN Product p
				ON vp.ProductId = p.ProductId
		JOIN ProductSubCategory sc
				ON p.ProductSubCategoryId = sc.ProductSubCategoryId
		JOIN ProductCategory pc
				ON sc.ProductCategoryId = pc.ProductCategoryId
		JOIN ProductBrand pb
			ON pb.ProductBrandId = p.ProductBrandId
WHERE	vp.VendorId = @VendorId
ORDER BY
		pc.SortCode, sc.SortCode, pb.BrandName, p.ProductName, p.Size

GO

GRANT EXECUTE ON dbo.GetVendorProductsByVendor TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetVendorProductsByVendorCategory
	@VendorId int,
	@ProductCategoryId int
AS

SELECT	vp.*
FROM	VendorProduct vp
		JOIN Product p
				ON vp.ProductId = p.ProductId
		JOIN ProductSubCategory sc
				ON p.ProductSubCategoryId = sc.ProductSubCategoryId
		JOIN ProductBrand pb
			ON pb.ProductBrandId = p.ProductBrandId
WHERE	vp.VendorId = @VendorId
		AND sc.ProductCategoryId = @ProductCategoryId
ORDER BY
		sc.SortCode, pb.BrandName, p.ProductName, p.Size

GO

GRANT EXECUTE ON dbo.GetVendorProductsByVendorCategory TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetVendorProductsByProduct
	@ProductId int
AS

SELECT	vp.*
FROM	VendorProduct vp
WHERE	vp.ProductId = @ProductId
ORDER BY
		vp.VendorProductId

GO

GRANT EXECUTE ON dbo.GetVendorProductsByProduct TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetVendorProductsByPartNum
	@VendorId int,
	@VendorPartNum varchar(30)
AS

SELECT	vp.*
FROM	VendorProduct vp
WHERE	vp.VendorId = @VendorId
		AND vp.VendorPartNum = @VendorPartNum

GO

GRANT EXECUTE ON dbo.GetVendorProductsByPartNum TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetVendorCategoryByBrand
	@ProductBrandId int
AS

SELECT	DISTINCT vp.VendorId, su.ProductCategoryId
FROM	VendorProduct vp
		JOIN Product pr ON vp.ProductId = pr.ProductId
		JOIN ProductSubCategory su ON pr.ProductSubCategoryId = su.ProductSubCategoryId
WHERE	pr.ProductBrandId = @ProductBrandId
ORDER BY
		vp.VendorId, su.ProductCategoryId

GO

GRANT EXECUTE ON dbo.GetVendorCategoryByBrand TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetProductsByVendor
	@VendorId int
AS

SELECT	p.*
FROM	VendorProduct vp
		JOIN Product p
				ON vp.ProductId = p.ProductId
		JOIN ProductSubCategory sc
				ON p.ProductSubCategoryId = sc.ProductSubCategoryId
		JOIN ProductCategory pc
				ON sc.ProductCategoryId = pc.ProductCategoryId
WHERE	vp.VendorId = @VendorId
ORDER BY
		pc.SortCode, sc.SortCode, p.ProductName, p.Size

GO

GRANT EXECUTE ON dbo.GetProductsByVendor TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetProductsByVendorCategory
	@VendorId int,
	@ProductCategoryId int
AS

SELECT	p.*
FROM	VendorProduct vp
		JOIN Product p
				ON vp.ProductId = p.ProductId
		JOIN ProductSubCategory sc
				ON p.ProductSubCategoryId = sc.ProductSubCategoryId
WHERE	vp.VendorId = @VendorId
		AND sc.ProductCategoryId = @ProductCategoryId
ORDER BY
		sc.SortCode, p.ProductName, p.Size

GO

GRANT EXECUTE ON dbo.GetProductsByVendorCategory TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetProductsByBrandCategory
	@BrandId int,
	@ProductCategoryId int
AS

SELECT	p.*
FROM	Product p
		JOIN ProductSubCategory sc
				ON p.ProductSubCategoryId = sc.ProductSubCategoryId
WHERE	p.ProductBrandId = @BrandId
		AND sc.ProductCategoryId = @ProductCategoryId
ORDER BY
		sc.SortCode, p.ProductName, p.Size

GO

GRANT EXECUTE ON dbo.GetProductsByBrandCategory TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetProductsByBrandNameSize
	@BrandId int,
	@ProductName varchar(100),
	@Size varchar(30)
AS

SELECT	p.*
FROM	Product p
WHERE	p.ProductBrandId = @BrandId
		AND p.ProductName = @ProductName
		AND p.Size = @Size
ORDER BY
		p.ProductId

GO

GRANT EXECUTE ON dbo.GetProductsByBrandNameSize TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetPurOrderByOrderDate
	@StartDate smalldatetime,
	@EndDate smalldatetime
AS

SELECT	*
FROM	PurOrder
WHERE	OrderDate >= @StartDate
		AND OrderDate <= @EndDate
ORDER BY
		OrderDate DESC

GO

GRANT EXECUTE ON dbo.GetPurOrderByOrderDate TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetPurOrderByVendorProduct
	@VendorProductId int
AS

SELECT	* 
FROM	PurLinesForProduct
WHERE	VendorProductIdSel = @VendorProductId
ORDER BY
		OrderDate DESC

GO

GRANT EXECUTE ON dbo.GetPurOrderByVendorProduct TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetPurLineByPurOrder
	@OrderId int
AS

SELECT	pl.*
FROM	PurLine pl
		JOIN ProductSubCategory ps
			ON pl.ProductSubCategoryId = ps.ProductSubCategoryId
		JOIN ProductCategory pc
			ON ps.ProductCategoryId = pc.ProductCategoryId
		JOIN ProductBrand pb
			ON pb.ProductBrandId = pl.ProductBrandId
WHERE	pl.PurOrderId = @OrderId
ORDER BY
		pc.SortCode, ps.SortCode, pb.BrandName, pl.ProductName, pl.Size

GO

GRANT EXECUTE ON dbo.GetPurLineByPurOrder TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.GetPurLineByShelfOrder
	@OrderId int
AS

SELECT	pl.*
FROM	PurLine pl
		JOIN ProductSubCategory ps
			ON pl.ProductSubCategoryId = ps.ProductSubCategoryId
		JOIN ProductCategory pc
			ON ps.ProductCategoryId = pc.ProductCategoryId
		JOIN ProductBrand pb
			ON pb.ProductBrandId = pl.ProductBrandId
WHERE	pl.PurOrderId = @OrderId
ORDER BY
		pc.SortCode, ps.SortCode, pl.ShelfOrder, pb.BrandName, pl.ProductName, pl.Size

GO

GRANT EXECUTE ON dbo.GetPurLineByShelfOrder TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.PurLineGetCategories
	@OrderId int
AS

SELECT	DISTINCT pc.*
FROM	PurLine pl
		JOIN VendorProduct vp
			ON pl.VendorProductId = vp.VendorProductId
		JOIN Product pr
			ON vp.ProductId = pr.ProductId
		JOIN ProductSubCategory ps
			ON pr.ProductSubCategoryId = ps.ProductSubCategoryId
		JOIN ProductCategory pc
			ON ps.ProductCategoryId = pc.ProductCategoryId
WHERE	pl.PurOrderId = @OrderId
ORDER BY
		pc.SortCode

GO

GRANT EXECUTE ON dbo.PurLineGetCategories TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.PurLineAddCategory
	@OrderId int,
	@CategoryId int,
	@IncludeInactive int
AS

DECLARE	@VendorId int

SELECT	@VendorId = VendorId
FROM	PurOrder
WHERE	PurOrderId = @OrderId

INSERT	PurLine (PurOrderId, VendorProductId, ProductName, ProductSubCategoryId, Size,
		ProductBrandId, RetailPrice, RetailPriceOverride, CaseCostOverride, EachCostOverride,
		OrderedEaches,
		QtyOrdered, QtyReceived, QtyBackordered, QtyDamaged, QtyMissing, QtyOnHand,
		ManufacturerBarcode, ManufacturerPartNum, Notes, ShelfOrder, VendorPartNum,
		CaseCost, CountInCase, EachCost, PreferredSource, WholeCasesOnly,
		SpecialOrder, CreateDate, ModifyDate)
SELECT	@OrderId, vp.VendorProductId, pr.ProductName, pr.ProductSubCategoryId, pr.Size,
		pr.ProductBrandId, pr.RetailPrice, vp.RetailPriceOverride, 0, 0,
		CASE WHEN vp.CaseCost>0 THEN 0 ELSE 1 END,
		0, 0, 0, 0, 0, 0,
		pr.ManufacturerBarcode, pr.ManufacturerPartNum, '', vp.ShelfOrder, vp.VendorPartNum,
		vp.CaseCost, vp.CountInCase, vp.EachCost, vp.PreferredSource, vp.WholeCasesOnly,
		0, getdate(), getdate()
FROM	VendorProduct vp
		JOIN Product pr
			ON vp.ProductId = pr.ProductId
		JOIN ProductSubCategory ps
			ON pr.ProductSubCategoryId = ps.ProductSubCategoryId
WHERE	ps.ProductCategoryId = @CategoryId
		AND vp.VendorId = @VendorId
		AND ((vp.IsActive > 0 AND pr.IsActive > 0) OR (@IncludeInactive > 0))
		AND (vp.IsProductDeleted = 0 AND pr.IsProductDeleted = 0)
		AND NOT EXISTS
		(
		SELECT	*
		FROM	PurLine pl
		WHERE	pl.VendorProductId = vp.VendorProductId
				AND pl.PurOrderId = @OrderId
		)
GO

GRANT EXECUTE ON dbo.PurLineAddCategory TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.PurLineRemoveCategory
	@OrderId int,
	@CategoryId int,
	@LinesRemaining int out
AS

DECLARE	@VendorId int

SELECT	@VendorId = VendorId
FROM	PurOrder
WHERE	PurOrderId = @OrderId

SELECT	@LinesRemaining = COUNT(*)
FROM	PurLine pl
		JOIN VendorProduct vp
			ON pl.VendorProductId = vp.VendorProductId
		JOIN Product pr
			ON vp.ProductId = pr.ProductId
		JOIN ProductSubCategory ps
			ON pr.ProductSubCategoryId = ps.ProductSubCategoryId
WHERE	ps.ProductCategoryId = @CategoryId
		AND vp.VendorId = @VendorId
		AND (pl.QtyOrdered <> 0
		OR pl.QtyReceived <> 0
		OR pl.QtyBackordered <> 0
		OR pl.QtyDamaged <> 0
		OR pl.QtyMissing <> 0
		OR pl.QtyOnHand <> 0)
		AND pl.PurOrderId = @OrderId

DELETE	PurLine
FROM	PurLine pl
		JOIN VendorProduct vp
			ON pl.VendorProductId = vp.VendorProductId
		JOIN Product pr
			ON vp.ProductId = pr.ProductId
		JOIN ProductSubCategory ps
			ON pr.ProductSubCategoryId = ps.ProductSubCategoryId
WHERE	ps.ProductCategoryId = @CategoryId
		AND vp.VendorId = @VendorId
		AND pl.QtyOrdered = 0
		AND pl.QtyReceived = 0
		AND pl.QtyBackordered = 0
		AND pl.QtyDamaged = 0
		AND pl.QtyMissing = 0
		AND pl.QtyOnHand = 0
		AND pl.PurOrderId = @OrderId
GO

GRANT EXECUTE ON dbo.PurLineRemoveCategory TO Programs
GO

-----------------------------------------------------

CREATE PROC dbo.PurLineRefreshFromDefinitions
	@VendorId int
AS

UPDATE	PurLine
SET		ProductName = pr.ProductName,
		ProductSubCategoryId = pr.ProductSubCategoryId,
		Size = pr.Size,
		ProductBrandId = pr.ProductBrandId,
		ManufacturerBarcode = pr.ManufacturerBarcode, 
		ManufacturerPartNum = pr.ManufacturerPartNum
FROM	PurLine pl
		JOIN
		VendorProduct vp
			ON pl.VendorProductId = vp.VendorProductId
		JOIN Product pr
			ON vp.ProductId = pr.ProductId
WHERE vp.VendorId = @VendorId

GO

GRANT EXECUTE ON dbo.PurLineRefreshFromDefinitions TO Programs
GO


-----------------------------------------------------

CREATE PROC dbo.PurLineSaveToDefinitions
	@OrderId int
AS

UPDATE	Product
SET		RetailPrice = CASE WHEN pl.RetailPrice <> 0 THEN pl.RetailPrice ELSE pr.RetailPrice END,
		ProductName = pl.ProductName,
		ProductSubCategoryId = pl.ProductSubCategoryId,
		Size = pl.Size,
		ProductBrandId = pl.ProductBrandId,
		ManufacturerBarcode = pl.ManufacturerBarcode, 
		ManufacturerPartNum = pl.ManufacturerPartNum
FROM	PurLine pl
		JOIN VendorProduct vp
			ON pl.VendorProductId = vp.VendorProductId
		JOIN Product pr
			ON vp.ProductId = pr.ProductId
WHERE	pl.PurOrderId = @OrderId

UPDATE	VendorProduct
SET		RetailPriceOverride = CASE WHEN pl.RetailPriceOverride <> 0 THEN pl.RetailPriceOverride ELSE vp.RetailPriceOverride END,
		CaseCost = CASE WHEN pl.CaseCost <> 0 THEN pl.CaseCost ELSE vp.CaseCost END, 
		CountInCase = CASE WHEN pl.CountInCase <> 0 THEN pl.CountInCase ELSE vp.CountInCase END, 
		EachCost = CASE WHEN pl.EachCost <> 0 THEN pl.EachCost ELSE vp.EachCost END
FROM	PurLine pl
		JOIN VendorProduct vp
			ON pl.VendorProductId = vp.VendorProductId
WHERE	pl.PurOrderId = @OrderId

GO

GRANT EXECUTE ON dbo.PurLineSaveToDefinitions TO Programs
GO

