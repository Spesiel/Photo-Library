using System;

namespace PhotoLibrary.Cache.Objects
{
    [Serializable]
    public struct Exif
    {
        public bool HasBeenSet { get; set; }

        #region Exif

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

        #endregion Exif

        public void SetValue(string property, byte[] value)
        {
            GetType().GetProperty(property).SetValue(this, Convert.ToBase64String(value));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode")]
        public override int GetHashCode()
        {
            int ans = HasBeenSet.GetHashCode();
            ans ^= PropertyTagGpsVer.GetHashCode();
            ans ^= PropertyTagGpsLatitudeRef.GetHashCode();
            ans ^= PropertyTagGpsLatitude.GetHashCode();
            ans ^= PropertyTagGpsLongitudeRef.GetHashCode();
            ans ^= PropertyTagGpsLongitude.GetHashCode();
            ans ^= PropertyTagGpsAltitudeRef.GetHashCode();
            ans ^= PropertyTagGpsAltitude.GetHashCode();
            ans ^= PropertyTagGpsGpsTime.GetHashCode();
            ans ^= PropertyTagGpsGpsSatellites.GetHashCode();
            ans ^= PropertyTagGpsGpsStatus.GetHashCode();
            ans ^= PropertyTagGpsGpsMeasureMode.GetHashCode();
            ans ^= PropertyTagGpsGpsDop.GetHashCode();
            ans ^= PropertyTagGpsSpeedRef.GetHashCode();
            ans ^= PropertyTagGpsSpeed.GetHashCode();
            ans ^= PropertyTagGpsTrackRef.GetHashCode();
            ans ^= PropertyTagGpsTrack.GetHashCode();
            ans ^= PropertyTagGpsImgDirRef.GetHashCode();
            ans ^= PropertyTagGpsImgDir.GetHashCode();
            ans ^= PropertyTagGpsMapDatum.GetHashCode();
            ans ^= PropertyTagGpsDestLatRef.GetHashCode();
            ans ^= PropertyTagGpsDestLat.GetHashCode();
            ans ^= PropertyTagGpsDestLongRef.GetHashCode();
            ans ^= PropertyTagGpsDestLong.GetHashCode();
            ans ^= PropertyTagGpsDestBearRef.GetHashCode();
            ans ^= PropertyTagGpsDestBear.GetHashCode();
            ans ^= PropertyTagGpsDestDistRef.GetHashCode();
            ans ^= PropertyTagGpsDestDist.GetHashCode();
            ans ^= PropertyTagNewSubfileType.GetHashCode();
            ans ^= PropertyTagSubfileType.GetHashCode();
            ans ^= PropertyTagImageWidth.GetHashCode();
            ans ^= PropertyTagImageHeight.GetHashCode();
            ans ^= PropertyTagBitsPerSample.GetHashCode();
            ans ^= PropertyTagCompression.GetHashCode();
            ans ^= PropertyTagPhotometricInterp.GetHashCode();
            ans ^= PropertyTagThreshHolding.GetHashCode();
            ans ^= PropertyTagCellWidth.GetHashCode();
            ans ^= PropertyTagCellHeight.GetHashCode();
            ans ^= PropertyTagFillOrder.GetHashCode();
            ans ^= PropertyTagDocumentName.GetHashCode();
            ans ^= PropertyTagImageDescription.GetHashCode();
            ans ^= PropertyTagEquipMake.GetHashCode();
            ans ^= PropertyTagEquipModel.GetHashCode();
            ans ^= PropertyTagStripOffsets.GetHashCode();
            ans ^= PropertyTagOrientation.GetHashCode();
            ans ^= PropertyTagSamplesPerPixel.GetHashCode();
            ans ^= PropertyTagRowsPerStrip.GetHashCode();
            ans ^= PropertyTagStripBytesCount.GetHashCode();
            ans ^= PropertyTagMinSampleValue.GetHashCode();
            ans ^= PropertyTagMaxSampleValue.GetHashCode();
            ans ^= PropertyTagXResolution.GetHashCode();
            ans ^= PropertyTagYResolution.GetHashCode();
            ans ^= PropertyTagPlanarConfig.GetHashCode();
            ans ^= PropertyTagPageName.GetHashCode();
            ans ^= PropertyTagXPosition.GetHashCode();
            ans ^= PropertyTagYPosition.GetHashCode();
            ans ^= PropertyTagFreeOffset.GetHashCode();
            ans ^= PropertyTagFreeByteCounts.GetHashCode();
            ans ^= PropertyTagGrayResponseUnit.GetHashCode();
            ans ^= PropertyTagGrayResponseCurve.GetHashCode();
            ans ^= PropertyTagT4Option.GetHashCode();
            ans ^= PropertyTagT6Option.GetHashCode();
            ans ^= PropertyTagResolutionUnit.GetHashCode();
            ans ^= PropertyTagPageNumber.GetHashCode();
            ans ^= PropertyTagTransferFunction.GetHashCode();
            ans ^= PropertyTagSoftwareUsed.GetHashCode();
            ans ^= PropertyTagDateTime.GetHashCode();
            ans ^= PropertyTagArtist.GetHashCode();
            ans ^= PropertyTagHostComputer.GetHashCode();
            ans ^= PropertyTagPredictor.GetHashCode();
            ans ^= PropertyTagWhitePoint.GetHashCode();
            ans ^= PropertyTagPrimaryChromaticities.GetHashCode();
            ans ^= PropertyTagColorMap.GetHashCode();
            ans ^= PropertyTagHalftoneHints.GetHashCode();
            ans ^= PropertyTagTileWidth.GetHashCode();
            ans ^= PropertyTagTileLength.GetHashCode();
            ans ^= PropertyTagTileOffset.GetHashCode();
            ans ^= PropertyTagTileByteCounts.GetHashCode();
            ans ^= PropertyTagInkSet.GetHashCode();
            ans ^= PropertyTagInkNames.GetHashCode();
            ans ^= PropertyTagNumberOfInks.GetHashCode();
            ans ^= PropertyTagDotRange.GetHashCode();
            ans ^= PropertyTagTargetPrinter.GetHashCode();
            ans ^= PropertyTagExtraSamples.GetHashCode();
            ans ^= PropertyTagSampleFormat.GetHashCode();
            ans ^= PropertyTagSMinSampleValue.GetHashCode();
            ans ^= PropertyTagSMaxSampleValue.GetHashCode();
            ans ^= PropertyTagTransferRange.GetHashCode();
            ans ^= PropertyTagJPEGProc.GetHashCode();
            ans ^= PropertyTagJPEGInterFormat.GetHashCode();
            ans ^= PropertyTagJPEGInterLength.GetHashCode();
            ans ^= PropertyTagJPEGRestartInterval.GetHashCode();
            ans ^= PropertyTagJPEGLosslessPredictors.GetHashCode();
            ans ^= PropertyTagJPEGPointTransforms.GetHashCode();
            ans ^= PropertyTagJPEGQTables.GetHashCode();
            ans ^= PropertyTagJPEGDCTables.GetHashCode();
            ans ^= PropertyTagJPEGACTables.GetHashCode();
            ans ^= PropertyTagYCbCrCoefficients.GetHashCode();
            ans ^= PropertyTagYCbCrSubsampling.GetHashCode();
            ans ^= PropertyTagYCbCrPositioning.GetHashCode();
            ans ^= PropertyTagREFBlackWhite.GetHashCode();
            ans ^= PropertyTagGamma.GetHashCode();
            ans ^= PropertyTagICCProfileDescriptor.GetHashCode();
            ans ^= PropertyTagSRGBRenderingIntent.GetHashCode();
            ans ^= PropertyTagImageTitle.GetHashCode();
            ans ^= PropertyTagResolutionXUnit.GetHashCode();
            ans ^= PropertyTagResolutionYUnit.GetHashCode();
            ans ^= PropertyTagResolutionXLengthUnit.GetHashCode();
            ans ^= PropertyTagResolutionYLengthUnit.GetHashCode();
            ans ^= PropertyTagPrintFlags.GetHashCode();
            ans ^= PropertyTagPrintFlagsVersion.GetHashCode();
            ans ^= PropertyTagPrintFlagsCrop.GetHashCode();
            ans ^= PropertyTagPrintFlagsBleedWidth.GetHashCode();
            ans ^= PropertyTagPrintFlagsBleedWidthScale.GetHashCode();
            ans ^= PropertyTagHalftoneLPI.GetHashCode();
            ans ^= PropertyTagHalftoneLPIUnit.GetHashCode();
            ans ^= PropertyTagHalftoneDegree.GetHashCode();
            ans ^= PropertyTagHalftoneShape.GetHashCode();
            ans ^= PropertyTagHalftoneMisc.GetHashCode();
            ans ^= PropertyTagHalftoneScreen.GetHashCode();
            ans ^= PropertyTagJPEGQuality.GetHashCode();
            ans ^= PropertyTagGridSize.GetHashCode();
            ans ^= PropertyTagThumbnailFormat.GetHashCode();
            ans ^= PropertyTagThumbnailWidth.GetHashCode();
            ans ^= PropertyTagThumbnailHeight.GetHashCode();
            ans ^= PropertyTagThumbnailColorDepth.GetHashCode();
            ans ^= PropertyTagThumbnailPlanes.GetHashCode();
            ans ^= PropertyTagThumbnailRawBytes.GetHashCode();
            ans ^= PropertyTagThumbnailSize.GetHashCode();
            ans ^= PropertyTagThumbnailCompressedSize.GetHashCode();
            ans ^= PropertyTagColorTransferFunction.GetHashCode();
            ans ^= PropertyTagThumbnailData.GetHashCode();
            ans ^= PropertyTagThumbnailImageWidth.GetHashCode();
            ans ^= PropertyTagThumbnailImageHeight.GetHashCode();
            ans ^= PropertyTagThumbnailBitsPerSample.GetHashCode();
            ans ^= PropertyTagThumbnailCompression.GetHashCode();
            ans ^= PropertyTagThumbnailPhotometricInterp.GetHashCode();
            ans ^= PropertyTagThumbnailImageDescription.GetHashCode();
            ans ^= PropertyTagThumbnailEquipMake.GetHashCode();
            ans ^= PropertyTagThumbnailEquipModel.GetHashCode();
            ans ^= PropertyTagThumbnailStripOffsets.GetHashCode();
            ans ^= PropertyTagThumbnailOrientation.GetHashCode();
            ans ^= PropertyTagThumbnailSamplesPerPixel.GetHashCode();
            ans ^= PropertyTagThumbnailRowsPerStrip.GetHashCode();
            ans ^= PropertyTagThumbnailStripBytesCount.GetHashCode();
            ans ^= PropertyTagThumbnailResolutionX.GetHashCode();
            ans ^= PropertyTagThumbnailResolutionY.GetHashCode();
            ans ^= PropertyTagThumbnailPlanarConfig.GetHashCode();
            ans ^= PropertyTagThumbnailResolutionUnit.GetHashCode();
            ans ^= PropertyTagThumbnailTransferFunction.GetHashCode();
            ans ^= PropertyTagThumbnailSoftwareUsed.GetHashCode();
            ans ^= PropertyTagThumbnailDateTime.GetHashCode();
            ans ^= PropertyTagThumbnailArtist.GetHashCode();
            ans ^= PropertyTagThumbnailWhitePoint.GetHashCode();
            ans ^= PropertyTagThumbnailPrimaryChromaticities.GetHashCode();
            ans ^= PropertyTagThumbnailYCbCrCoefficients.GetHashCode();
            ans ^= PropertyTagThumbnailYCbCrSubsampling.GetHashCode();
            ans ^= PropertyTagThumbnailYCbCrPositioning.GetHashCode();
            ans ^= PropertyTagThumbnailRefBlackWhite.GetHashCode();
            ans ^= PropertyTagThumbnailCopyRight.GetHashCode();
            ans ^= PropertyTagLuminanceTable.GetHashCode();
            ans ^= PropertyTagChrominanceTable.GetHashCode();
            ans ^= PropertyTagFrameDelay.GetHashCode();
            ans ^= PropertyTagLoopCount.GetHashCode();
            ans ^= PropertyTagGlobalPalette.GetHashCode();
            ans ^= PropertyTagIndexBackground.GetHashCode();
            ans ^= PropertyTagIndexTransparent.GetHashCode();
            ans ^= PropertyTagPixelUnit.GetHashCode();
            ans ^= PropertyTagPixelPerUnitX.GetHashCode();
            ans ^= PropertyTagPixelPerUnitY.GetHashCode();
            ans ^= PropertyTagPaletteHistogram.GetHashCode();
            ans ^= PropertyTagCopyright.GetHashCode();
            ans ^= PropertyTagExifExposureTime.GetHashCode();
            ans ^= PropertyTagExifFNumber.GetHashCode();
            ans ^= PropertyTagExifIFD.GetHashCode();
            ans ^= PropertyTagICCProfile.GetHashCode();
            ans ^= PropertyTagExifExposureProg.GetHashCode();
            ans ^= PropertyTagExifSpectralSense.GetHashCode();
            ans ^= PropertyTagGpsIFD.GetHashCode();
            ans ^= PropertyTagExifISOSpeed.GetHashCode();
            ans ^= PropertyTagExifOECF.GetHashCode();
            ans ^= PropertyTagExifVer.GetHashCode();
            ans ^= PropertyTagExifDTOrig.GetHashCode();
            ans ^= PropertyTagExifDTDigitized.GetHashCode();
            ans ^= PropertyTagExifCompConfig.GetHashCode();
            ans ^= PropertyTagExifCompBPP.GetHashCode();
            ans ^= PropertyTagExifShutterSpeed.GetHashCode();
            ans ^= PropertyTagExifAperture.GetHashCode();
            ans ^= PropertyTagExifBrightness.GetHashCode();
            ans ^= PropertyTagExifExposureBias.GetHashCode();
            ans ^= PropertyTagExifMaxAperture.GetHashCode();
            ans ^= PropertyTagExifSubjectDist.GetHashCode();
            ans ^= PropertyTagExifMeteringMode.GetHashCode();
            ans ^= PropertyTagExifLightSource.GetHashCode();
            ans ^= PropertyTagExifFlash.GetHashCode();
            ans ^= PropertyTagExifFocalLength.GetHashCode();
            ans ^= PropertyTagExifMakerNote.GetHashCode();
            ans ^= PropertyTagExifUserComment.GetHashCode();
            ans ^= PropertyTagExifDTSubsec.GetHashCode();
            ans ^= PropertyTagExifDTOrigSS.GetHashCode();
            ans ^= PropertyTagExifDTDigSS.GetHashCode();
            ans ^= PropertyTagExifFPXVer.GetHashCode();
            ans ^= PropertyTagExifColorSpace.GetHashCode();
            ans ^= PropertyTagExifPixXDim.GetHashCode();
            ans ^= PropertyTagExifPixYDim.GetHashCode();
            ans ^= PropertyTagExifRelatedWav.GetHashCode();
            ans ^= PropertyTagExifInterop.GetHashCode();
            ans ^= PropertyTagExifFlashEnergy.GetHashCode();
            ans ^= PropertyTagExifSpatialFR.GetHashCode();
            ans ^= PropertyTagExifFocalXRes.GetHashCode();
            ans ^= PropertyTagExifFocalYRes.GetHashCode();
            ans ^= PropertyTagExifFocalResUnit.GetHashCode();
            ans ^= PropertyTagExifSubjectLoc.GetHashCode();
            ans ^= PropertyTagExifExposureIndex.GetHashCode();
            ans ^= PropertyTagExifSensingMethod.GetHashCode();
            ans ^= PropertyTagExifFileSource.GetHashCode();
            ans ^= PropertyTagExifSceneType.GetHashCode();
            ans ^= PropertyTagExifCfaPattern.GetHashCode();
            return ans;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Exif))
                return false;

            return Equals((Exif)obj);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public bool Equals(Exif other)
        {
            if (HasBeenSet == false && HasBeenSet == other.HasBeenSet)
                return true;

            if (PropertyTagGpsVer != other.PropertyTagGpsVer ||
                PropertyTagGpsLatitudeRef != other.PropertyTagGpsLatitudeRef ||
                PropertyTagGpsLatitude != other.PropertyTagGpsLatitude ||
                PropertyTagGpsLongitudeRef != other.PropertyTagGpsLongitudeRef ||
                PropertyTagGpsLongitude != other.PropertyTagGpsLongitude ||
                PropertyTagGpsAltitudeRef != other.PropertyTagGpsAltitudeRef ||
                PropertyTagGpsAltitude != other.PropertyTagGpsAltitude ||
                PropertyTagGpsGpsTime != other.PropertyTagGpsGpsTime ||
                PropertyTagGpsGpsSatellites != other.PropertyTagGpsGpsSatellites ||
                PropertyTagGpsGpsStatus != other.PropertyTagGpsGpsStatus ||
                PropertyTagGpsGpsMeasureMode != other.PropertyTagGpsGpsMeasureMode ||
                PropertyTagGpsGpsDop != other.PropertyTagGpsGpsDop ||
                PropertyTagGpsSpeedRef != other.PropertyTagGpsSpeedRef ||
                PropertyTagGpsSpeed != other.PropertyTagGpsSpeed ||
                PropertyTagGpsTrackRef != other.PropertyTagGpsTrackRef ||
                PropertyTagGpsTrack != other.PropertyTagGpsTrack ||
                PropertyTagGpsImgDirRef != other.PropertyTagGpsImgDirRef ||
                PropertyTagGpsImgDir != other.PropertyTagGpsImgDir ||
                PropertyTagGpsMapDatum != other.PropertyTagGpsMapDatum ||
                PropertyTagGpsDestLatRef != other.PropertyTagGpsDestLatRef ||
                PropertyTagGpsDestLat != other.PropertyTagGpsDestLat ||
                PropertyTagGpsDestLongRef != other.PropertyTagGpsDestLongRef ||
                PropertyTagGpsDestLong != other.PropertyTagGpsDestLong ||
                PropertyTagGpsDestBearRef != other.PropertyTagGpsDestBearRef ||
                PropertyTagGpsDestBear != other.PropertyTagGpsDestBear ||
                PropertyTagGpsDestDistRef != other.PropertyTagGpsDestDistRef ||
                PropertyTagGpsDestDist != other.PropertyTagGpsDestDist ||
                PropertyTagNewSubfileType != other.PropertyTagNewSubfileType ||
                PropertyTagSubfileType != other.PropertyTagSubfileType ||
                PropertyTagImageWidth != other.PropertyTagImageWidth ||
                PropertyTagImageHeight != other.PropertyTagImageHeight ||
                PropertyTagBitsPerSample != other.PropertyTagBitsPerSample ||
                PropertyTagCompression != other.PropertyTagCompression ||
                PropertyTagPhotometricInterp != other.PropertyTagPhotometricInterp ||
                PropertyTagThreshHolding != other.PropertyTagThreshHolding ||
                PropertyTagCellWidth != other.PropertyTagCellWidth ||
                PropertyTagCellHeight != other.PropertyTagCellHeight ||
                PropertyTagFillOrder != other.PropertyTagFillOrder ||
                PropertyTagDocumentName != other.PropertyTagDocumentName ||
                PropertyTagImageDescription != other.PropertyTagImageDescription ||
                PropertyTagEquipMake != other.PropertyTagEquipMake ||
                PropertyTagEquipModel != other.PropertyTagEquipModel ||
                PropertyTagStripOffsets != other.PropertyTagStripOffsets ||
                PropertyTagOrientation != other.PropertyTagOrientation ||
                PropertyTagSamplesPerPixel != other.PropertyTagSamplesPerPixel ||
                PropertyTagRowsPerStrip != other.PropertyTagRowsPerStrip ||
                PropertyTagStripBytesCount != other.PropertyTagStripBytesCount ||
                PropertyTagMinSampleValue != other.PropertyTagMinSampleValue ||
                PropertyTagMaxSampleValue != other.PropertyTagMaxSampleValue ||
                PropertyTagXResolution != other.PropertyTagXResolution ||
                PropertyTagYResolution != other.PropertyTagYResolution ||
                PropertyTagPlanarConfig != other.PropertyTagPlanarConfig ||
                PropertyTagPageName != other.PropertyTagPageName ||
                PropertyTagXPosition != other.PropertyTagXPosition ||
                PropertyTagYPosition != other.PropertyTagYPosition ||
                PropertyTagFreeOffset != other.PropertyTagFreeOffset ||
                PropertyTagFreeByteCounts != other.PropertyTagFreeByteCounts ||
                PropertyTagGrayResponseUnit != other.PropertyTagGrayResponseUnit ||
                PropertyTagGrayResponseCurve != other.PropertyTagGrayResponseCurve ||
                PropertyTagT4Option != other.PropertyTagT4Option ||
                PropertyTagT6Option != other.PropertyTagT6Option ||
                PropertyTagResolutionUnit != other.PropertyTagResolutionUnit ||
                PropertyTagPageNumber != other.PropertyTagPageNumber ||
                PropertyTagTransferFunction != other.PropertyTagTransferFunction ||
                PropertyTagSoftwareUsed != other.PropertyTagSoftwareUsed ||
                PropertyTagDateTime != other.PropertyTagDateTime ||
                PropertyTagArtist != other.PropertyTagArtist ||
                PropertyTagHostComputer != other.PropertyTagHostComputer ||
                PropertyTagPredictor != other.PropertyTagPredictor ||
                PropertyTagWhitePoint != other.PropertyTagWhitePoint ||
                PropertyTagPrimaryChromaticities != other.PropertyTagPrimaryChromaticities ||
                PropertyTagColorMap != other.PropertyTagColorMap ||
                PropertyTagHalftoneHints != other.PropertyTagHalftoneHints ||
                PropertyTagTileWidth != other.PropertyTagTileWidth ||
                PropertyTagTileLength != other.PropertyTagTileLength ||
                PropertyTagTileOffset != other.PropertyTagTileOffset ||
                PropertyTagTileByteCounts != other.PropertyTagTileByteCounts ||
                PropertyTagInkSet != other.PropertyTagInkSet ||
                PropertyTagInkNames != other.PropertyTagInkNames ||
                PropertyTagNumberOfInks != other.PropertyTagNumberOfInks ||
                PropertyTagDotRange != other.PropertyTagDotRange ||
                PropertyTagTargetPrinter != other.PropertyTagTargetPrinter ||
                PropertyTagExtraSamples != other.PropertyTagExtraSamples ||
                PropertyTagSampleFormat != other.PropertyTagSampleFormat ||
                PropertyTagSMinSampleValue != other.PropertyTagSMinSampleValue ||
                PropertyTagSMaxSampleValue != other.PropertyTagSMaxSampleValue ||
                PropertyTagTransferRange != other.PropertyTagTransferRange ||
                PropertyTagJPEGProc != other.PropertyTagJPEGProc ||
                PropertyTagJPEGInterFormat != other.PropertyTagJPEGInterFormat ||
                PropertyTagJPEGInterLength != other.PropertyTagJPEGInterLength ||
                PropertyTagJPEGRestartInterval != other.PropertyTagJPEGRestartInterval ||
                PropertyTagJPEGLosslessPredictors != other.PropertyTagJPEGLosslessPredictors ||
                PropertyTagJPEGPointTransforms != other.PropertyTagJPEGPointTransforms ||
                PropertyTagJPEGQTables != other.PropertyTagJPEGQTables ||
                PropertyTagJPEGDCTables != other.PropertyTagJPEGDCTables ||
                PropertyTagJPEGACTables != other.PropertyTagJPEGACTables ||
                PropertyTagYCbCrCoefficients != other.PropertyTagYCbCrCoefficients ||
                PropertyTagYCbCrSubsampling != other.PropertyTagYCbCrSubsampling ||
                PropertyTagYCbCrPositioning != other.PropertyTagYCbCrPositioning ||
                PropertyTagREFBlackWhite != other.PropertyTagREFBlackWhite ||
                PropertyTagGamma != other.PropertyTagGamma ||
                PropertyTagICCProfileDescriptor != other.PropertyTagICCProfileDescriptor ||
                PropertyTagSRGBRenderingIntent != other.PropertyTagSRGBRenderingIntent ||
                PropertyTagImageTitle != other.PropertyTagImageTitle ||
                PropertyTagResolutionXUnit != other.PropertyTagResolutionXUnit ||
                PropertyTagResolutionYUnit != other.PropertyTagResolutionYUnit ||
                PropertyTagResolutionXLengthUnit != other.PropertyTagResolutionXLengthUnit ||
                PropertyTagResolutionYLengthUnit != other.PropertyTagResolutionYLengthUnit ||
                PropertyTagPrintFlags != other.PropertyTagPrintFlags ||
                PropertyTagPrintFlagsVersion != other.PropertyTagPrintFlagsVersion ||
                PropertyTagPrintFlagsCrop != other.PropertyTagPrintFlagsCrop ||
                PropertyTagPrintFlagsBleedWidth != other.PropertyTagPrintFlagsBleedWidth ||
                PropertyTagPrintFlagsBleedWidthScale != other.PropertyTagPrintFlagsBleedWidthScale ||
                PropertyTagHalftoneLPI != other.PropertyTagHalftoneLPI ||
                PropertyTagHalftoneLPIUnit != other.PropertyTagHalftoneLPIUnit ||
                PropertyTagHalftoneDegree != other.PropertyTagHalftoneDegree ||
                PropertyTagHalftoneShape != other.PropertyTagHalftoneShape ||
                PropertyTagHalftoneMisc != other.PropertyTagHalftoneMisc ||
                PropertyTagHalftoneScreen != other.PropertyTagHalftoneScreen ||
                PropertyTagJPEGQuality != other.PropertyTagJPEGQuality ||
                PropertyTagGridSize != other.PropertyTagGridSize ||
                PropertyTagThumbnailFormat != other.PropertyTagThumbnailFormat ||
                PropertyTagThumbnailWidth != other.PropertyTagThumbnailWidth ||
                PropertyTagThumbnailHeight != other.PropertyTagThumbnailHeight ||
                PropertyTagThumbnailColorDepth != other.PropertyTagThumbnailColorDepth ||
                PropertyTagThumbnailPlanes != other.PropertyTagThumbnailPlanes ||
                PropertyTagThumbnailRawBytes != other.PropertyTagThumbnailRawBytes ||
                PropertyTagThumbnailSize != other.PropertyTagThumbnailSize ||
                PropertyTagThumbnailCompressedSize != other.PropertyTagThumbnailCompressedSize ||
                PropertyTagColorTransferFunction != other.PropertyTagColorTransferFunction ||
                PropertyTagThumbnailData != other.PropertyTagThumbnailData ||
                PropertyTagThumbnailImageWidth != other.PropertyTagThumbnailImageWidth ||
                PropertyTagThumbnailImageHeight != other.PropertyTagThumbnailImageHeight ||
                PropertyTagThumbnailBitsPerSample != other.PropertyTagThumbnailBitsPerSample ||
                PropertyTagThumbnailCompression != other.PropertyTagThumbnailCompression ||
                PropertyTagThumbnailPhotometricInterp != other.PropertyTagThumbnailPhotometricInterp ||
                PropertyTagThumbnailImageDescription != other.PropertyTagThumbnailImageDescription ||
                PropertyTagThumbnailEquipMake != other.PropertyTagThumbnailEquipMake ||
                PropertyTagThumbnailEquipModel != other.PropertyTagThumbnailEquipModel ||
                PropertyTagThumbnailStripOffsets != other.PropertyTagThumbnailStripOffsets ||
                PropertyTagThumbnailOrientation != other.PropertyTagThumbnailOrientation ||
                PropertyTagThumbnailSamplesPerPixel != other.PropertyTagThumbnailSamplesPerPixel ||
                PropertyTagThumbnailRowsPerStrip != other.PropertyTagThumbnailRowsPerStrip ||
                PropertyTagThumbnailStripBytesCount != other.PropertyTagThumbnailStripBytesCount ||
                PropertyTagThumbnailResolutionX != other.PropertyTagThumbnailResolutionX ||
                PropertyTagThumbnailResolutionY != other.PropertyTagThumbnailResolutionY ||
                PropertyTagThumbnailPlanarConfig != other.PropertyTagThumbnailPlanarConfig ||
                PropertyTagThumbnailResolutionUnit != other.PropertyTagThumbnailResolutionUnit ||
                PropertyTagThumbnailTransferFunction != other.PropertyTagThumbnailTransferFunction ||
                PropertyTagThumbnailSoftwareUsed != other.PropertyTagThumbnailSoftwareUsed ||
                PropertyTagThumbnailDateTime != other.PropertyTagThumbnailDateTime ||
                PropertyTagThumbnailArtist != other.PropertyTagThumbnailArtist ||
                PropertyTagThumbnailWhitePoint != other.PropertyTagThumbnailWhitePoint ||
                PropertyTagThumbnailPrimaryChromaticities != other.PropertyTagThumbnailPrimaryChromaticities ||
                PropertyTagThumbnailYCbCrCoefficients != other.PropertyTagThumbnailYCbCrCoefficients ||
                PropertyTagThumbnailYCbCrSubsampling != other.PropertyTagThumbnailYCbCrSubsampling ||
                PropertyTagThumbnailYCbCrPositioning != other.PropertyTagThumbnailYCbCrPositioning ||
                PropertyTagThumbnailRefBlackWhite != other.PropertyTagThumbnailRefBlackWhite ||
                PropertyTagThumbnailCopyRight != other.PropertyTagThumbnailCopyRight ||
                PropertyTagLuminanceTable != other.PropertyTagLuminanceTable ||
                PropertyTagChrominanceTable != other.PropertyTagChrominanceTable ||
                PropertyTagFrameDelay != other.PropertyTagFrameDelay ||
                PropertyTagLoopCount != other.PropertyTagLoopCount ||
                PropertyTagGlobalPalette != other.PropertyTagGlobalPalette ||
                PropertyTagIndexBackground != other.PropertyTagIndexBackground ||
                PropertyTagIndexTransparent != other.PropertyTagIndexTransparent ||
                PropertyTagPixelUnit != other.PropertyTagPixelUnit ||
                PropertyTagPixelPerUnitX != other.PropertyTagPixelPerUnitX ||
                PropertyTagPixelPerUnitY != other.PropertyTagPixelPerUnitY ||
                PropertyTagPaletteHistogram != other.PropertyTagPaletteHistogram ||
                PropertyTagCopyright != other.PropertyTagCopyright ||
                PropertyTagExifExposureTime != other.PropertyTagExifExposureTime ||
                PropertyTagExifFNumber != other.PropertyTagExifFNumber ||
                PropertyTagExifIFD != other.PropertyTagExifIFD ||
                PropertyTagICCProfile != other.PropertyTagICCProfile ||
                PropertyTagExifExposureProg != other.PropertyTagExifExposureProg ||
                PropertyTagExifSpectralSense != other.PropertyTagExifSpectralSense ||
                PropertyTagGpsIFD != other.PropertyTagGpsIFD ||
                PropertyTagExifISOSpeed != other.PropertyTagExifISOSpeed ||
                PropertyTagExifOECF != other.PropertyTagExifOECF ||
                PropertyTagExifVer != other.PropertyTagExifVer ||
                PropertyTagExifDTOrig != other.PropertyTagExifDTOrig ||
                PropertyTagExifDTDigitized != other.PropertyTagExifDTDigitized ||
                PropertyTagExifCompConfig != other.PropertyTagExifCompConfig ||
                PropertyTagExifCompBPP != other.PropertyTagExifCompBPP ||
                PropertyTagExifShutterSpeed != other.PropertyTagExifShutterSpeed ||
                PropertyTagExifAperture != other.PropertyTagExifAperture ||
                PropertyTagExifBrightness != other.PropertyTagExifBrightness ||
                PropertyTagExifExposureBias != other.PropertyTagExifExposureBias ||
                PropertyTagExifMaxAperture != other.PropertyTagExifMaxAperture ||
                PropertyTagExifSubjectDist != other.PropertyTagExifSubjectDist ||
                PropertyTagExifMeteringMode != other.PropertyTagExifMeteringMode ||
                PropertyTagExifLightSource != other.PropertyTagExifLightSource ||
                PropertyTagExifFlash != other.PropertyTagExifFlash ||
                PropertyTagExifFocalLength != other.PropertyTagExifFocalLength ||
                PropertyTagExifMakerNote != other.PropertyTagExifMakerNote ||
                PropertyTagExifUserComment != other.PropertyTagExifUserComment ||
                PropertyTagExifDTSubsec != other.PropertyTagExifDTSubsec ||
                PropertyTagExifDTOrigSS != other.PropertyTagExifDTOrigSS ||
                PropertyTagExifDTDigSS != other.PropertyTagExifDTDigSS ||
                PropertyTagExifFPXVer != other.PropertyTagExifFPXVer ||
                PropertyTagExifColorSpace != other.PropertyTagExifColorSpace ||
                PropertyTagExifPixXDim != other.PropertyTagExifPixXDim ||
                PropertyTagExifPixYDim != other.PropertyTagExifPixYDim ||
                PropertyTagExifRelatedWav != other.PropertyTagExifRelatedWav ||
                PropertyTagExifInterop != other.PropertyTagExifInterop ||
                PropertyTagExifFlashEnergy != other.PropertyTagExifFlashEnergy ||
                PropertyTagExifSpatialFR != other.PropertyTagExifSpatialFR ||
                PropertyTagExifFocalXRes != other.PropertyTagExifFocalXRes ||
                PropertyTagExifFocalYRes != other.PropertyTagExifFocalYRes ||
                PropertyTagExifFocalResUnit != other.PropertyTagExifFocalResUnit ||
                PropertyTagExifSubjectLoc != other.PropertyTagExifSubjectLoc ||
                PropertyTagExifExposureIndex != other.PropertyTagExifExposureIndex ||
                PropertyTagExifSensingMethod != other.PropertyTagExifSensingMethod ||
                PropertyTagExifFileSource != other.PropertyTagExifFileSource ||
                PropertyTagExifSceneType != other.PropertyTagExifSceneType ||
                PropertyTagExifCfaPattern != other.PropertyTagExifCfaPattern)
                return false;

            return true;
        }

        public static bool operator ==(Exif item1, Exif item2)
        {
            return item1.Equals(item2);
        }

        public static bool operator !=(Exif item1, Exif item2)
        {
            return !item1.Equals(item2);
        }
    }
}