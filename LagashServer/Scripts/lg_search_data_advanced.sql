--/////////////////////////////////////////////////////////////////////////////////////////////////
-- drop procedure dbo.lg_search_data
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[lg_search_data]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[lg_search_data]
GO

CREATE PROCEDURE [dbo].[lg_search_data]
	@typeSearch as varchar(50) ='THESES',
	@isAll as Bit = 1,
	@filter as varchar(100)= '',
	@autorList as nvarchar(max),
	@editorialList as nvarchar(max),
	@yearList as nvarchar(max),
	@descriptorList as nvarchar(max),
	@indexerList as nvarchar(max),
	/********   pager  ****/
    @page			int =1,
    @numRows		int =10
    /******** end pager****/
AS
BEGIN
declare @startRowIndex int,
		@total int
 SET @startRowIndex = ((@page - 1) * @numRows) + 1;		


declare @list table(
	Id    VARCHAR(36),
    Title VARCHAR(150),
	Autor VARCHAR(150),
	AutorCode varchar(150),
	Editorial varchar(150),
	MaterialCode varchar(150),
	MaterialYear varchar(150),
	Type varchar(150),
	Image VARCHAR(100),
	RowNumber int identity
);

if(@isAll = 1 or @typeSearch='Books')
begin
	insert into @list
	select 
		b._id,
		b.title Title,
		'' autor,
		b.code_author,
		e.name,
		b.code_material,
		b.year,
		'books' Type,
		b.image Image 
	--select b.*
	from Books b 
	left join Editorials e on b.editorial_id = e._id
	--left join AuthorMaps am on b._id = am.material_id
	--left join Authors a on a._id = am.author_id
	
	where 
		(
		b.title like ('%'+ @filter +'%') 
		--or a.first_name like ('%'+ @filter +'%')
		)
		and (
			(@yearList ='') or 
			(@yearList !='' and b.year in( select value from STRING_SPLIT (@yearList, ',')))
		)
		and (
			(@editorialList = '' ) or
			(@editorialList != '' and e.name in(select value from STRING_SPLIT (@editorialList, ',')))
		)
		and (
			(@autorList = '' ) or
			(@autorList !='' and a.first_name in(select value from STRING_SPLIT (@autorList, ',')))
		)
		
		--and (--materias
		--	(@descriptorList = '' ) or
		--	(@descriptorList !='' and b.illustrations in(select value from STRING_SPLIT (@descriptorList, ',')))
		--)

		and b.enabled = 1
		
end

--if(@isAll = 1 or @typeSearch='Thesis')
--begin
--	insert into @list
--	select 
--		t._id,
--		t.title Title, 
--		a.first_name as autor,
--		t.code_author,
--		e.name,
--		t.code_material,
--		t.year,
--		'thesis' Type,
--		t.image Image
--	from Theses t 
--	left join AuthorMaps am on t._id = am.material_id
--	left join Authors a on a._id = am.author_id
--	left join Editorials e on t.editorial_id = e._id

--	where (title like ('%'+ @filter +'%') 
--		or a.first_name like ('%'+ @filter +'%'))
--		or (
--			(@yearList ='') or-- and t.year LIKE CAST(@filter AS NVARCHAR) + '%' ) or
--			(@yearList !='' and t.year in( select value from STRING_SPLIT (@yearList, ',')))
--		)
--		and (
--			(@editorialList ='' ) or
--			(@editorialList !='' and e.name in( select value from STRING_SPLIT (@editorialList, ',')))
--		)
		
--		and (
--			(@autorList = '' ) or
--			(@autorList !='' and a.first_name in( select value from STRING_SPLIT (@autorList, ',')))
--		)
--		and t.enabled = 1
--end

--if(@isAll = 1 or @typeSearch='Magazines')
--begin
--	insert into @list
--	select 
--		m._id,
--		m.title Title,
--		'' as autor, 
--		m.code_author,
--		e.name,
--		m.code_material,
--		m.year,
--		'magazines' Type,
--		m.image Image 
--	from Magazines m
--	left join Editorials e on m.editorial_id = e._id

--	where m.title like ('%'+ @filter +'%') 
--	or (
--			(@yearList ='') or-- and m.year LIKE CAST(@filter AS NVARCHAR) + '%' ) or
--			(@yearList !='' and m.year in( select value from STRING_SPLIT (@yearList, ',')))
--		)
--		and (
--			(@editorialList ='' ) or
--			(@editorialList !='' and e.name in( select value from STRING_SPLIT (@editorialList, ',')))
--		)
--		and m.enabled = 1
--end

--if(@isAll = 1 or @typeSearch='Newspapers')
--begin
--	insert into @list
--	select 
--		e._id,
--		n.title Title,
--		a.first_name autor, 
--		n.code_author,
--		e.name,
--		n.code_material,
--		n.year,
--		'newspapers' Type,
--		e.image Image
--	from Newspapers n
--	left join AuthorMaps am on n._id = am.material_id
--	left join Authors a on a._id = am.author_id
--	left join Editorials e on n.editorial_id = e._id
--	where n.title like ('%'+ @filter +'%') 
--	or (
--			(@yearList ='') or-- and n.year LIKE CAST(@filter AS NVARCHAR) + '%' ) or
--			(@yearList !='' and n.year in( select value from STRING_SPLIT (@yearList, ',')))
--		)
--		and (
--			(@editorialList ='' ) or
--			(@editorialList !='' and e.name in( select value from STRING_SPLIT (@editorialList, ',')))
--		)
--		and n.enabled = 1
--end

set @total = (select count(*) from @list)

select  distinct *, @total Total from @list where RowNumber BETWEEN @startRowIndex AND @startRowIndex + @numRows - 1 



--;WITH cte 
--     AS (SELECT Id, 
--                Title, 
--                Autor, 
--                AutorCode, 
--                quantity=Sum( @total )  OVER(partition BY Id), 
--                rn = Row_number() 
--                       OVER( 
--                         partition BY Id 
--                         ORDER BY title ASC) 
--         FROM   @list) 
--SELECT Id, 
--       Title, 
--       Autor, 
--       AutorCode, 
--       quantity 
--FROM   cte 
--WHERE  rn = 1 

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
-- 
--exec dbo.lg_search_data typeSearch/isAll/filter/author/editorial/year/descriptor/indexer/page/pagesize
exec dbo.lg_search_data '', 1, '','','','','','', 1, 30

--books/thesis/magazines/newspapers


--declare @text varchar(max) ='camera'
--select b.title, b.tags-- where (select value from STRING_SPLIT (@text,',') where b.tags like CONCAT('%',value,'%'))
--from books b
--where
--tags in ( select b2.tags from books b2 where b2.tags in (
--			select value from STRING_SPLIT (@text, ',')
--			where b2.tags like CONCAT('%',value,'%')
--			)
--		)


--DECLARE @Test VARCHAR(100)
--SET @Test='cables'

--select _id, title, tags from books 
--where tags in(select b2.value from STRING_SPLIT(@Test, ',') b2 where tags like concat('%', b2.value ,'%'))

--select title, tags from books where tags is not null and tags !=''
--SELECT title, tags FROM books a 
--WHERE ISNULL(a.tags, '') LIKE (CASE WHEN isnull(@Test,'') = '' THEN isnull(a.tags,'') 
--                                        ELSE '%'+@Test+'%' END)  


--SELECT title, tags
--FROM books a
--WHERE (@test IS NULL OR a.tags LIKE '%'+@test+'%')

--select title, tags from books where tags is not null and tags !=''





--as d where d.value like 'na%')



--CREATE FUNCTION [dbo].[SplitTExt]
--(@String nvarchar(max), @Delimiter char(1))
--RETURNS @Results TABLE (Items varchar(200))
--AS
--BEGIN
--DECLARE @INDEX INT
--DECLARE @SLICE nvarchar(max)
---- HAVE TO SET TO 1 SO IT DOESNT EQUAL Z
----     ERO FIRST TIME IN LOOP
--SELECT @INDEX = 1
--WHILE @INDEX !=0
--BEGIN
---- GET THE INDEX OF THE FIRST OCCURENCE OF THE SPLIT CHARACTER
--SELECT @INDEX = CHARINDEX(@Delimiter,@STRING)
---- NOW PUSH EVERYTHING TO THE LEFT OF IT INTO THE SLICE VARIABLE
--IF @INDEX !=0
--SELECT @SLICE = LEFT(@STRING,@INDEX - 1)
--ELSE
--SELECT @SLICE = @STRING
---- PUT THE ITEM INTO THE RESULTS SET
--INSERT INTO @Results(Items) VALUES(@SLICE)
---- CHOP THE ITEM REMOVED OFF THE MAIN STRING
--SELECT @STRING = RIGHT(@STRING,LEN(@STRING) - @INDEX)
---- BREAK OUT IF WE ARE DONE
--IF LEN(@STRING) = 0 BREAK
--END
--RETURN
--END
--GO



 --DECLARE @Data VARCHAR(50) ='photo,cables'
 --DECLARE @Query VARCHAR(MAX)=''

 --SELECT @Query+='tags LIKE ''%''+'''+value+'''+''%'' AND ' 
 --FROM STRING_SPLIT(@Data,',')

 --SET @Query='SELECT tags FROM books WHERE '+ SUBSTRING(@Query,1,LEN(@Query)-4)
 --EXEC(@Query)

