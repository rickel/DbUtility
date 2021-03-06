﻿using Ivony.Data;
using Ivony.Data.Common;
using Ivony.Data.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ivony.Data.SqlClient
{

  /// <summary>
  /// 定义 SQL Server 的参数化查询解析器
  /// </summary>
  public class SqlParameterizedQueryParser : ParameterizedQueryParser<SqlCommand, SqlParameter>
  {



    /// <summary>
    /// 创建参数并获取参数占位符
    /// </summary>
    /// <param name="value">参数值</param>
    /// <param name="index">在模板中参数的位置顺序</param>
    /// <param name="parameter">创建的参数对象</param>
    /// <returns>参数占位符</returns>
    protected override string GetParameterPlaceholder( object value, int index, out SqlParameter parameter )
    {
      var name = "@Param" + index;
      parameter = new SqlParameter( name, value );

      return name;
    }


    /// <summary>
    /// 创建 SqlCommand 对象
    /// </summary>
    /// <param name="commandText">经过分析后的 SQL 查询文本</param>
    /// <param name="parameters">参数值列表</param>
    /// <returns>用于执行查询的 SqlCommand 对象</returns>
    protected override SqlCommand CreateCommand( string commandText, SqlParameter[] parameters )
    {
      var command = new SqlCommand();

      command.CommandText = commandText;
      command.Parameters.AddRange( parameters );

      return command;
    }
  }
}
