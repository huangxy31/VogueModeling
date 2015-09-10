using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace VagueRegionModelling.DataOperator
{
    /// <summary>
    /// 存储输入输出相关信息
    /// </summary>
    public class DataInformation
    {
        private IMapControl3 m_mapControl = null;
        private string m_fileName = string.Empty;
        private ILayer m_inputLayer = null;
        private string m_filePath = string.Empty;       
        private string m_layerName = string.Empty;

        public DataInformation()
        { }

        public DataInformation(IMapControl3 mapControl, string fileName)
        {
            m_mapControl = mapControl;
            m_fileName = fileName;
        }

        #region Get member value
        public string GetFileName()
        {
            return m_fileName;
        }

        public string GetFilePath()
        {
            return m_filePath;
        }
        public ILayer GetInputLayer()
        {
            if (m_layerName != null && m_inputLayer == null)
                m_inputLayer = GetLayerByName();
            return m_inputLayer;
        }
        #endregion

        #region Set member value
        public void SetFileName(string fileName)
        {
            m_fileName = fileName;
        }
        public void SetFilePath(string filePath)
        {
            m_filePath = filePath;
        }
        public void SetLayerName(string layerName)
        {
            m_layerName = layerName;
        }
        #endregion

        public ILayer GetLayerByName()
        {
            ILayer Layer = null;
            for (int i = 0; i < m_mapControl.LayerCount; i++)
            {
                Layer = m_mapControl.Map.get_Layer(i);
                if (Layer.Name == m_layerName)
                    break;
            }
            return Layer as ILayer;
        }
    }
}
