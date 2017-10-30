using Dicom;
using Dicom.Imaging;
using Dicom.IO.Buffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiViewBox
{
    class DICOMUtils
    {
        public static void SaveToDICOMFile(short[] pixels,int noRows,int noCols,string fileName)
        {
            DicomDataset dataset = new DicomDataset();
            byte[] buf = new byte[2*noCols*noRows];
            Buffer.BlockCopy(pixels, 0, buf, 0, 2 * noCols * noRows);
            FillDataset(dataset);
            dataset.Add(DicomTag.PixelAspectRatio, noRows.ToString()+"\\"+noCols.ToString());
            dataset.Add(DicomTag.PhotometricInterpretation, PhotometricInterpretation.Monochrome2.Value);
            dataset.Add(DicomTag.Rows, (ushort)noRows);
            dataset.Add(DicomTag.Columns, (ushort)noCols);
            dataset.Add(DicomTag.BitsStored, (ushort)16);
            dataset.Add(DicomTag.BitsAllocated, (ushort)16);
            dataset.Add(DicomTag.HighBit, (ushort)15);
            DicomPixelData pixelData = DicomPixelData.Create(dataset, true);
            pixelData.BitsStored = 16;
            //pixelData.BitsAllocated = 16;
            pixelData.SamplesPerPixel = 1;
            pixelData.HighBit = 15;
            pixelData.PixelRepresentation = PixelRepresentation.Unsigned;
            pixelData.PlanarConfiguration = 0;
            MemoryByteBuffer pixelsInBytes = new MemoryByteBuffer(buf);
            pixelData.AddFrame(pixelsInBytes);

            DicomFile dicomfile = new DicomFile(dataset);
            dicomfile.Save(fileName);
        }

        private static void FillDataset(DicomDataset dataset)
        {
            //type 1 attributes.
            dataset.Add(DicomTag.SOPClassUID, DicomUID.MRImageStorage);
            dataset.Add(DicomTag.StudyInstanceUID, GenerateUid());
            dataset.Add(DicomTag.SeriesInstanceUID, GenerateUid());
            dataset.Add(DicomTag.SOPInstanceUID, GenerateUid());

            //type 2 attributes
            dataset.Add(DicomTag.PatientID, "12345");
            dataset.Add(DicomTag.PatientName, string.Empty);
            dataset.Add(DicomTag.PatientBirthDate, "00000000");
            dataset.Add(DicomTag.PatientSex, "M");
            dataset.Add(DicomTag.StudyDate, DateTime.Now);
            dataset.Add(DicomTag.StudyTime, DateTime.Now);
            dataset.Add(DicomTag.AccessionNumber, string.Empty);
            dataset.Add(DicomTag.ReferringPhysicianName, string.Empty);
            dataset.Add(DicomTag.StudyID, "1");
            dataset.Add(DicomTag.SeriesNumber, "1");
            dataset.Add(DicomTag.ModalitiesInStudy, "MR");
            dataset.Add(DicomTag.Modality, "MR");
            dataset.Add(DicomTag.NumberOfStudyRelatedInstances, "1");
            dataset.Add(DicomTag.NumberOfStudyRelatedSeries, "1");
            dataset.Add(DicomTag.NumberOfSeriesRelatedInstances, "1");
            dataset.Add(DicomTag.PatientOrientation, "F/A");
            dataset.Add(DicomTag.ImageLaterality, "U");
            
            //dataset.Add(DicomTag.BitsStored, 16);
            //dataset.Add(DicomTag.BitsAllocated, 16);
            //dataset.Add(DicomTag.HighBit, 15);
        }

        private static DicomUID GenerateUid()
        {
            StringBuilder uid = new StringBuilder();
            uid.Append("1.08.1982.10121984.2.0.07").Append('.').Append(DateTime.UtcNow.Ticks);
            return new DicomUID(uid.ToString(), "SOP Instance UID", DicomUidType.SOPInstance);
        }
    }
}
