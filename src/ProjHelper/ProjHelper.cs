
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
class ProjHelper
{
    public static bool ProjectionWGS84ToPseudoMercator(double lat, double lon, out double x, out double y)
    {
        CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();

        ICoordinateSystem wgs84 = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;
        ICoordinateSystem pseudoMercator = ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WebMercator;

        ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(wgs84, pseudoMercator);

        double[] fromPoint = new double[] { lon, lat };
        double[] toPoint = trans.MathTransform.Transform(fromPoint);

        x = toPoint[0];
        y = toPoint[1];
    
        return true;
    }

    public static bool ProjectionWGS84ToCGCS2000(double lat, double lon, out double x, out double y)
    {
        CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();

        ICoordinateSystem wgs84 = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;
        ICoordinateSystem cgcs2000 = ctfac.CreateFromWkt(@"PROJCS[""CGCS2000 / 3-degree Gauss-Kruger zone 33"",
            GEOGCS[""CGCS2000"",
                DATUM[""China_Geodetic_Coordinate_System_2000"",
                    SPHEROID[""CGCS2000"",6378137,298.257222101,
                        AUTHORITY[""EPSG"",""1024""]],
                    AUTHORITY[""EPSG"",""1043""]],
                PRIMEM[""Greenwich"",0,
                    AUTHORITY[""EPSG"",""8901""]],
                UNIT[""degree"",0.01745329251994328,
                    AUTHORITY[""EPSG"",""9122""]],
                AUTHORITY[""EPSG"",""4490""]],
            PROJECTION[""Transverse_Mercator""],
            PARAMETER[""latitude_of_origin"",0],
            PARAMETER[""central_meridian"",99],
            PARAMETER[""scale_factor"",1],
            PARAMETER[""false_easting"",33500000],
            PARAMETER[""false_northing"",0],
            UNIT[""metre"",1,
                AUTHORITY[""EPSG"",""9001""]],
            AUTHORITY[""EPSG"",""4547""]]");


        ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(wgs84, cgcs2000);

        double[] fromPoint = new double[] { lon, lat };
        double[] toPoint = trans.MathTransform.Transform(fromPoint);

        x = toPoint[0];
        y = toPoint[1];
    
        return true;
    }
}