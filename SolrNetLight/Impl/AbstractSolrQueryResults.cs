﻿using System;
using System.Collections.Generic;
using SolrNetLight.Utils;

namespace SolrNetLight.Impl {
    public abstract class AbstractSolrQueryResults<T> : List<T> {
        /// <summary>
        /// Total documents found
        /// </summary>
        public int NumFound { get; set; }

        /// <summary>
        /// Max score in these results
        /// </summary>
        public double? MaxScore { get; set; }

        /// <summary>
        /// Query response header
        /// </summary>
        public ResponseHeader Header { get; set; }

        /// <summary>
        /// Facet query results
        /// </summary>
        public IDictionary<string, int> FacetQueries { get; set; }

        /// <summary>
        /// Facet field results
        /// </summary>
        public IDictionary<string, ICollection<KeyValuePair<string, int>>> FacetFields { get; set; }

        /// <summary>
        /// Facet date results
        /// </summary>
        public IDictionary<string, DateFacetingResult> FacetDates { get; set; }


        protected AbstractSolrQueryResults() {
            FacetQueries = new Dictionary<string, int>();
            FacetFields = new Dictionary<string, ICollection<KeyValuePair<string, int>>>();
            FacetDates = new Dictionary<string, DateFacetingResult>();
        }

        /// <summary>
        /// Visitor / pattern match
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="query"></param>
        /// <param name="moreLikeThis"></param>
        /// <returns></returns>
        public abstract R Switch<R>(Func<SolrQueryResults<T>, R> query);

        /// <summary>
        /// Visitor / pattern match
        /// </summary>
        /// <param name="query"></param>
        /// <param name="moreLikeThis"></param>
        public void Switch(Action<SolrQueryResults<T>> query) {
            Switch(F.ToFunc(query));
        }
    }
}