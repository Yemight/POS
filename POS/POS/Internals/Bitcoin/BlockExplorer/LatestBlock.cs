﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using Lib.JSON.Linq;

namespace Info.Blockchain.API.BlockExplorer
{
    /// <summary>
    /// Used as a response to the `GetLatestBlock` method in the `BlockExplorer` class.
    /// </summary>
    public class LatestBlock : SimpleBlock
    {
        public LatestBlock(JObject b) : base(b, true)
        {
            this.Index = (long)b["block_index"];

            var txs = b["txIndexes"].AsJEnumerable().Select(x => (long)x).ToList();
            this.TransactionIndexes = txs.AsReadOnly();
        }

        /// <summary>
        /// Block index
        /// </summary>
        public long Index { get; private set; }

        /// <summary>
        /// Transaction indexes included in this block
        /// </summary>
        public ReadOnlyCollection<long> TransactionIndexes { get; private set; }
    }
}