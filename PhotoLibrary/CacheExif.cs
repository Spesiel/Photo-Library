﻿using System;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace PhotoLibrary
{
    [Serializable]
    public struct CacheExif
    {
        public bool HasBeenSet { get; set; }

        #region Properties

        public string PropertyTagGpsVer { get; set; }
        public string PropertyTagGpsLatitudeRef { get; set; }
        public string PropertyTagGpsLatitude { get; set; }
        public string PropertyTagGpsLongitudeRef { get; set; }
        public string PropertyTagGpsLongitude { get; set; }
        public string PropertyTagGpsAltitudeRef { get; set; }
        public string PropertyTagGpsAltitude { get; set; }
        public string PropertyTagGpsGpsTime { get; set; }
        public string PropertyTagGpsGpsSatellites { get; set; }
        public string PropertyTagGpsGpsStatus { get; set; }
        public string PropertyTagGpsGpsMeasureMode { get; set; }
        public string PropertyTagGpsGpsDop { get; set; }
        public string PropertyTagGpsSpeedRef { get; set; }
        public string PropertyTagGpsSpeed { get; set; }
        public string PropertyTagGpsTrackRef { get; set; }
        public string PropertyTagGpsTrack { get; set; }
        public string PropertyTagGpsImgDirRef { get; set; }
        public string PropertyTagGpsImgDir { get; set; }
        public string PropertyTagGpsMapDatum { get; set; }
        public string PropertyTagGpsDestLatRef { get; set; }
        public string PropertyTagGpsDestLat { get; set; }
        public string PropertyTagGpsDestLongRef { get; set; }
        public string PropertyTagGpsDestLong { get; set; }
        public string PropertyTagGpsDestBearRef { get; set; }
        public string PropertyTagGpsDestBear { get; set; }
        public string PropertyTagGpsDestDistRef { get; set; }
        public string PropertyTagGpsDestDist { get; set; }
        public string PropertyTagNewSubfileType { get; set; }
        public string PropertyTagSubfileType { get; set; }
        public string PropertyTagImageWidth { get; set; }
        public string PropertyTagImageHeight { get; set; }
        public string PropertyTagBitsPerSample { get; set; }
        public string PropertyTagCompression { get; set; }
        public string PropertyTagPhotometricInterp { get; set; }
        public string PropertyTagThreshHolding { get; set; }
        public string PropertyTagCellWidth { get; set; }
        public string PropertyTagCellHeight { get; set; }
        public string PropertyTagFillOrder { get; set; }
        public string PropertyTagDocumentName { get; set; }
        public string PropertyTagImageDescription { get; set; }
        public string PropertyTagEquipMake { get; set; }
        public string PropertyTagEquipModel { get; set; }
        public string PropertyTagStripOffsets { get; set; }
        public string PropertyTagOrientation { get; set; }
        public string PropertyTagSamplesPerPixel { get; set; }
        public string PropertyTagRowsPerStrip { get; set; }
        public string PropertyTagStripBytesCount { get; set; }
        public string PropertyTagMinSampleValue { get; set; }
        public string PropertyTagMaxSampleValue { get; set; }
        public string PropertyTagXResolution { get; set; }
        public string PropertyTagYResolution { get; set; }
        public string PropertyTagPlanarConfig { get; set; }
        public string PropertyTagPageName { get; set; }
        public string PropertyTagXPosition { get; set; }
        public string PropertyTagYPosition { get; set; }
        public string PropertyTagFreeOffset { get; set; }
        public string PropertyTagFreeByteCounts { get; set; }
        public string PropertyTagGrayResponseUnit { get; set; }
        public string PropertyTagGrayResponseCurve { get; set; }
        public string PropertyTagT4Option { get; set; }
        public string PropertyTagT6Option { get; set; }
        public string PropertyTagResolutionUnit { get; set; }
        public string PropertyTagPageNumber { get; set; }
        public string PropertyTagTransferFunction { get; set; }
        public string PropertyTagSoftwareUsed { get; set; }
        public string PropertyTagDateTime { get; set; }
        public string PropertyTagArtist { get; set; }
        public string PropertyTagHostComputer { get; set; }
        public string PropertyTagPredictor { get; set; }
        public string PropertyTagWhitePoint { get; set; }
        public string PropertyTagPrimaryChromaticities { get; set; }
        public string PropertyTagColorMap { get; set; }
        public string PropertyTagHalftoneHints { get; set; }
        public string PropertyTagTileWidth { get; set; }
        public string PropertyTagTileLength { get; set; }
        public string PropertyTagTileOffset { get; set; }
        public string PropertyTagTileByteCounts { get; set; }
        public string PropertyTagInkSet { get; set; }
        public string PropertyTagInkNames { get; set; }
        public string PropertyTagNumberOfInks { get; set; }
        public string PropertyTagDotRange { get; set; }
        public string PropertyTagTargetPrinter { get; set; }
        public string PropertyTagExtraSamples { get; set; }
        public string PropertyTagSampleFormat { get; set; }
        public string PropertyTagSMinSampleValue { get; set; }
        public string PropertyTagSMaxSampleValue { get; set; }
        public string PropertyTagTransferRange { get; set; }
        public string PropertyTagJPEGProc { get; set; }
        public string PropertyTagJPEGInterFormat { get; set; }
        public string PropertyTagJPEGInterLength { get; set; }
        public string PropertyTagJPEGRestartInterval { get; set; }
        public string PropertyTagJPEGLosslessPredictors { get; set; }
        public string PropertyTagJPEGPointTransforms { get; set; }
        public string PropertyTagJPEGQTables { get; set; }
        public string PropertyTagJPEGDCTables { get; set; }
        public string PropertyTagJPEGACTables { get; set; }
        public string PropertyTagYCbCrCoefficients { get; set; }
        public string PropertyTagYCbCrSubsampling { get; set; }
        public string PropertyTagYCbCrPositioning { get; set; }
        public string PropertyTagREFBlackWhite { get; set; }
        public string PropertyTagGamma { get; set; }
        public string PropertyTagICCProfileDescriptor { get; set; }
        public string PropertyTagSRGBRenderingIntent { get; set; }
        public string PropertyTagImageTitle { get; set; }
        public string PropertyTagResolutionXUnit { get; set; }
        public string PropertyTagResolutionYUnit { get; set; }
        public string PropertyTagResolutionXLengthUnit { get; set; }
        public string PropertyTagResolutionYLengthUnit { get; set; }
        public string PropertyTagPrintFlags { get; set; }
        public string PropertyTagPrintFlagsVersion { get; set; }
        public string PropertyTagPrintFlagsCrop { get; set; }
        public string PropertyTagPrintFlagsBleedWidth { get; set; }
        public string PropertyTagPrintFlagsBleedWidthScale { get; set; }
        public string PropertyTagHalftoneLPI { get; set; }
        public string PropertyTagHalftoneLPIUnit { get; set; }
        public string PropertyTagHalftoneDegree { get; set; }
        public string PropertyTagHalftoneShape { get; set; }
        public string PropertyTagHalftoneMisc { get; set; }
        public string PropertyTagHalftoneScreen { get; set; }
        public string PropertyTagJPEGQuality { get; set; }
        public string PropertyTagGridSize { get; set; }
        public string PropertyTagThumbnailFormat { get; set; }
        public string PropertyTagThumbnailWidth { get; set; }
        public string PropertyTagThumbnailHeight { get; set; }
        public string PropertyTagThumbnailColorDepth { get; set; }
        public string PropertyTagThumbnailPlanes { get; set; }
        public string PropertyTagThumbnailRawBytes { get; set; }
        public string PropertyTagThumbnailSize { get; set; }
        public string PropertyTagThumbnailCompressedSize { get; set; }
        public string PropertyTagColorTransferFunction { get; set; }
        public string PropertyTagThumbnailData { get; set; }
        public string PropertyTagThumbnailImageWidth { get; set; }
        public string PropertyTagThumbnailImageHeight { get; set; }
        public string PropertyTagThumbnailBitsPerSample { get; set; }
        public string PropertyTagThumbnailCompression { get; set; }
        public string PropertyTagThumbnailPhotometricInterp { get; set; }
        public string PropertyTagThumbnailImageDescription { get; set; }
        public string PropertyTagThumbnailEquipMake { get; set; }
        public string PropertyTagThumbnailEquipModel { get; set; }
        public string PropertyTagThumbnailStripOffsets { get; set; }
        public string PropertyTagThumbnailOrientation { get; set; }
        public string PropertyTagThumbnailSamplesPerPixel { get; set; }
        public string PropertyTagThumbnailRowsPerStrip { get; set; }
        public string PropertyTagThumbnailStripBytesCount { get; set; }
        public string PropertyTagThumbnailResolutionX { get; set; }
        public string PropertyTagThumbnailResolutionY { get; set; }
        public string PropertyTagThumbnailPlanarConfig { get; set; }
        public string PropertyTagThumbnailResolutionUnit { get; set; }
        public string PropertyTagThumbnailTransferFunction { get; set; }
        public string PropertyTagThumbnailSoftwareUsed { get; set; }
        public string PropertyTagThumbnailDateTime { get; set; }
        public string PropertyTagThumbnailArtist { get; set; }
        public string PropertyTagThumbnailWhitePoint { get; set; }
        public string PropertyTagThumbnailPrimaryChromaticities { get; set; }
        public string PropertyTagThumbnailYCbCrCoefficients { get; set; }
        public string PropertyTagThumbnailYCbCrSubsampling { get; set; }
        public string PropertyTagThumbnailYCbCrPositioning { get; set; }
        public string PropertyTagThumbnailRefBlackWhite { get; set; }
        public string PropertyTagThumbnailCopyRight { get; set; }
        public string PropertyTagLuminanceTable { get; set; }
        public string PropertyTagChrominanceTable { get; set; }
        public string PropertyTagFrameDelay { get; set; }
        public string PropertyTagLoopCount { get; set; }
        public string PropertyTagGlobalPalette { get; set; }
        public string PropertyTagIndexBackground { get; set; }
        public string PropertyTagIndexTransparent { get; set; }
        public string PropertyTagPixelUnit { get; set; }
        public string PropertyTagPixelPerUnitX { get; set; }
        public string PropertyTagPixelPerUnitY { get; set; }
        public string PropertyTagPaletteHistogram { get; set; }
        public string PropertyTagCopyright { get; set; }
        public string PropertyTagExifExposureTime { get; set; }
        public string PropertyTagExifFNumber { get; set; }
        public string PropertyTagExifIFD { get; set; }
        public string PropertyTagICCProfile { get; set; }
        public string PropertyTagExifExposureProg { get; set; }
        public string PropertyTagExifSpectralSense { get; set; }
        public string PropertyTagGpsIFD { get; set; }
        public string PropertyTagExifISOSpeed { get; set; }
        public string PropertyTagExifOECF { get; set; }
        public string PropertyTagExifVer { get; set; }
        public string PropertyTagExifDTOrig { get; set; }
        public string PropertyTagExifDTDigitized { get; set; }
        public string PropertyTagExifCompConfig { get; set; }
        public string PropertyTagExifCompBPP { get; set; }
        public string PropertyTagExifShutterSpeed { get; set; }
        public string PropertyTagExifAperture { get; set; }
        public string PropertyTagExifBrightness { get; set; }
        public string PropertyTagExifExposureBias { get; set; }
        public string PropertyTagExifMaxAperture { get; set; }
        public string PropertyTagExifSubjectDist { get; set; }
        public string PropertyTagExifMeteringMode { get; set; }
        public string PropertyTagExifLightSource { get; set; }
        public string PropertyTagExifFlash { get; set; }
        public string PropertyTagExifFocalLength { get; set; }
        public string PropertyTagExifMakerNote { get; set; }
        public string PropertyTagExifUserComment { get; set; }
        public string PropertyTagExifDTSubsec { get; set; }
        public string PropertyTagExifDTOrigSS { get; set; }
        public string PropertyTagExifDTDigSS { get; set; }
        public string PropertyTagExifFPXVer { get; set; }
        public string PropertyTagExifColorSpace { get; set; }
        public string PropertyTagExifPixXDim { get; set; }
        public string PropertyTagExifPixYDim { get; set; }
        public string PropertyTagExifRelatedWav { get; set; }
        public string PropertyTagExifInterop { get; set; }
        public string PropertyTagExifFlashEnergy { get; set; }
        public string PropertyTagExifSpatialFR { get; set; }
        public string PropertyTagExifFocalXRes { get; set; }
        public string PropertyTagExifFocalYRes { get; set; }
        public string PropertyTagExifFocalResUnit { get; set; }
        public string PropertyTagExifSubjectLoc { get; set; }
        public string PropertyTagExifExposureIndex { get; set; }
        public string PropertyTagExifSensingMethod { get; set; }
        public string PropertyTagExifFileSource { get; set; }
        public string PropertyTagExifSceneType { get; set; }
        public string PropertyTagExifCfaPattern { get; set; }

        #endregion Properties

        public void SetValue(string property, byte[] value)
        {
            GetType().GetProperty(property).SetValue(this, Convert.ToBase64String(value));
        }

        #region Translation to/from xml

        public string ToXml()
        {
            string ans = string.Empty;

            using (StringWriter writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CacheExif));
                serializer.Serialize(writer, this);
                ans = writer.ToString();
            }

            return ans;
        }

        public static string ToXml(CacheExif cacheExif)
        {
            string ans = string.Empty;

            using (StringWriter writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CacheExif));
                serializer.Serialize(writer, cacheExif);
                ans = writer.ToString();
            }

            return ans;
        }

        public static CacheExif FromXml(string xml)
        {
            CacheExif ans = new CacheExif();

            using (StringReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CacheExif));
                ans = (CacheExif)serializer.Deserialize(reader);
            }

            return ans;
        }

        #endregion Translation to/from xml
    }
}