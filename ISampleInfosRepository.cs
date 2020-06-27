using CSharpFunctionalExtensions;
using Sample.Api;
using System;
using System.Collections.Generic;

public interface ISampleInfosRepository
{
    Maybe<SampleInfo> Get(int id) => throw new NotImplementedException();

    IEnumerable<SampleInfo> GetRange(int skip, int take = 5);

    Result Add(SampleInfo sampleInfo);

    void AddRange(SampleInfo sampleInfo) => throw new NotImplementedException();
}