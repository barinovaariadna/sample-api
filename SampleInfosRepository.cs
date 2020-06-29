using System.Collections.Concurrent;
using System.Collections.Generic;
using Sample.Api;
using System.Linq;
using System;
using CSharpFunctionalExtensions;

public class SampleInfosRepository : ISampleInfosRepository
{
    private ConcurrentDictionary<int, SampleInfo> _sampleInfos = new ConcurrentDictionary<int, SampleInfo>();

    public IEnumerable<SampleInfo> GetRange(int skip, int take = 5)
    {
        return _sampleInfos.Skip(skip).Take(take).Select(x => x.Value);
    }

    public Result Add(SampleInfo sampleInfo)
    {
        return Result.FailureIf(!_sampleInfos.TryAdd(sampleInfo.Id, sampleInfo), "The element already exists");
    }
}