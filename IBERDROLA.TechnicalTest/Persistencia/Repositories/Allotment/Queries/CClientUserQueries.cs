namespace IBERDROLA.TechnicalTest.Persistence.Repositories.Allotment.Queries
{
    internal static class CClientUserQueries
    {
        internal const string CclientUser = @"
            DECLARE @Exists as bit=0;
			SELECT 
				@Exists=(CASE WHEN CU.idClienteUsuario IS NOT NULL THEN 1 ELSE 0 END)
FROM  cclienteusuario CU WITH(NOLOCK)
					INNER JOIN cCliente Cc
						ON Cc.idCliente = CU.idCliente
					WHERE 
						Cc.idCode = @Code
					AND 
						CU.idClienteUsuario = @IdAgent
			SELECT 
				@Exists as Exits
        ";

        internal const string CclientContact = @"
            
			SELECT 
				idClienteContacto 'B2BBuyerId'
			FROM 
				cclienteusuario c
	       INNER JOIN cCliente a
				ON c.idClienteUsuario = a.idCliente
			WHERE 
				a.idCode = @Code
			
        ";

        internal const string cCaja = @"
            
			DECLARE @Exists as bit=0;
			DECLARE @Box AS INT = 0;
			IF ( SELECT ISNULL(cnCajaAgencia, 0)
				FROM 
					cCliente 
				WHERE  
					idCliente = @IdClient ) = 1
			BEGIN
			  IF(	Select 
					  count(b.idCaja) 
				FROM 
					cAgenciaCaja a
				INNER JOIN 
					cCaja b on a.idCaja = b.idCaja 
				WHERE 
					a.idCliente =	@IdClient 
					and
					b.idCaja = @BoxOffice ) > 0 
					BEGIN 

						SET @Exists = 1

					END
					ELSE
					BEGIN
						SET @Exists = 0
					END
			END
			ELSE
			BEGIN
				Select 
					 @Box = idCaja  FROM cCaja 
				WHERE idCanalVenta = 0 and cnCajaDefault=1 

				IF @Box = @BoxOffice 
			BEGIN
				SET @Exists = 1
			END
			ELSE
			BEGIN
				SET @Exists = 0
			END

			END

			

			SELECT @Exists
	
        ";

		internal const string cHotelPickup = @"
			DECLARE @Exists as bit=0;
			SELECT
				@Exists=(CASE WHEN cHPHP.idHotelPickupHorarioProducto IS NOT NULL THEN 1 ELSE 0 END)
			FROM 
				cHotelPickupHorarioProducto cHPHP WITH(NOLOCK)  
			INNER JOIN 
				cHotelPickupHorarioMachote cHPHPM WITH(NOLOCK) 
			ON 
				cHPHP.idHotelPickupHorarioMachote = cHPHPM.idHotelPickupHorarioMachote  
			INNER JOIN 
				cHotelFechasOperacion cHFO WITH(NOLOCK) 
			ON 
				cHPHPM.idHotelFechasOperacion = cHFO.idHotelFechasOperacion  
			INNER JOIN 
				cHotel cH WITH(NOLOCK) 
			ON 
				cH.idHotel = cHFO.idHotel  
			WHERE 
				1=1
			AND 
				cHPHP.idHotelPickupHorarioProducto = @IdPickUp
			AND 
				idProducto = @IdProduct 
			  
			SELECT 
					@Exists as Exits

		";



    }
}
