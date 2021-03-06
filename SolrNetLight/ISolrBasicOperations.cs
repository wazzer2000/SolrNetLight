﻿#region license
// Copyright (c) 2007-2010 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using SolrNetLight.Commands.Parameters;

namespace SolrNetLight {
    /// <summary>
    /// Solr operations without convenience overloads
    /// </summary>
    /// <typeparam name="T">Document type</typeparam>
    public interface ISolrBasicOperations<T> : ISolrBasicReadOnlyOperations<T> {
        /// <summary>
        /// Commits posted documents
        /// </summary>
        /// <param name="options">Commit options</param>
        Task<ResponseHeader> Commit(CommitOptions options);

        /// <summary>
        /// Rollbacks all add/deletes made to the index since the last commit.
        /// </summary>
        Task<ResponseHeader> Rollback();

        /// <summary>
        /// Adds / updates several documents with index-time boost
        /// </summary>
        /// <param name="docs"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<ResponseHeader> AddWithBoost(IEnumerable<KeyValuePair<T, double?>> docs, AddParameters parameters);

        /// <summary>
        /// Sends a custom command
        /// </summary>
        /// <param name="cmd">command to send</param>
        /// <returns>solr response</returns>
        Task<string> Send(ISolrCommand cmd);

        /// <summary>
        /// Sends a custom command, returns parsed header from xml response
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<ResponseHeader> SendAndParseHeader(ISolrCommand cmd);

    }
}